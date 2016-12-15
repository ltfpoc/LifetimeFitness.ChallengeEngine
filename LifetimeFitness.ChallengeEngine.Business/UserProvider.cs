using LifetimeFitness.ChallengeEngine.Core;
using LifetimeFitness.ChallengeEngine.Core.Domin;
using LifetimeFitness.ChallengeEngine.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LifetimeFitness.ChallengeEngine.Business
{
    public class UserProvider
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<User> userRepository;

        public UserProvider()
        {
            userRepository = unitOfWork.Repository<User>();
        }

        public int Insert(User _Challenge)
        {
            return userRepository.Insert(_Challenge);
        }

        public int Update(User _Challenge)
        {
            return userRepository.Update(_Challenge);
        }

        public int Delete(User _Challenge)
        {
            return userRepository.Delete(_Challenge);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await userRepository.GetAll();
        }

        public async Task<IEnumerable<Userd>> GetAllUsers()
        {
            var entity = await userRepository.GetAll();
            var uentity = (from a in entity
                           select new Userd
                           {
                               UserId = a.UserId,
                               Name = a.FirstName + " " + a.LastName,
                               UserName = a.UserName,
                               UserRole = a.UserRole.Description
                           }
                    ).ToList();
            return uentity;
        }

        public async Task<IEnumerable<Userd>> GetUsersNotInChallenge(int _ChallengeId, int _clubId)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(_ChallengeId)) || !string.IsNullOrEmpty(Convert.ToString(_clubId)))
            {
                return null;
            }
            else
            {
                UserChallengeEnrollmentProvider _UserChallengeEnrollmentProvider = new Business.UserChallengeEnrollmentProvider();
                var userchallenge = await _UserChallengeEnrollmentProvider.GetAll();
                ChallengeClubRelationProvider _userChallengeEnrollmentProvider = new ChallengeClubRelationProvider();
                var challengeClubRelationship = await _userChallengeEnrollmentProvider.GetAll();
                var entity = await GetAll();
                var getcheck = (
                    from u in entity
                    where !(from u1 in userchallenge.Where(a => a.ChallengeId == _ChallengeId)
                            join c1 in challengeClubRelationship.Where(a => a.ClubId == _clubId)
                            on u1.ChallengeClubRelationId equals c1.ChallengeClubRelationId
                            select new
                            {
                                u1.UserId
                            }).Contains(new { UserId = u.UserId }) &&
                            u.RoleId == 3
                    select new Userd
                    {
                        UserId = u.UserId,
                        Name = u.FirstName + " " + u.LastName,
                        UserName = u.UserName,
                        UserRole = u.UserRole.Description
                    }
                    );
                if (getcheck.Any())
                {
                    return getcheck.ToList();
                }
                else
                {
                    var uentity = (from a in entity
                                   where a.RoleId == 3
                                   select new Userd
                                   {
                                       UserId = a.UserId,
                                       Name = a.FirstName + " " + a.LastName,
                                       UserName = a.UserName,
                                       UserRole = a.UserRole.Description
                                   }).Distinct();
                    return uentity.ToList();
                }
            }
        }

        public async Task<User> GetById(int _id)
        {
            return await userRepository.GetById(_id);
        }

        public async Task<ICollection<User>> FindBy(Expression<Func<User, bool>> predicate)
        {
            return await userRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<User>> GetAllBy(Expression<Func<User, bool>> filter = null, Func<IEnumerable<User>, IOrderedEnumerable<User>> orderBy = null)
        {
            return await userRepository.GetAllBy(filter, orderBy);
        }

        public string HashPassword(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
        public async Task<User> LoginUser(string userName, string password)
        {
            string hashPassword = HashPassword(password);
            var entity = await FindBy(u => u.UserName == userName && u.Password == hashPassword);
            return entity.FirstOrDefault();
        }

        public int RegisterUser(User usertoregister)
        {
            usertoregister.Password = HashPassword(usertoregister.Password);
            var result = Insert(usertoregister);
            return result;
        }

    }
}
