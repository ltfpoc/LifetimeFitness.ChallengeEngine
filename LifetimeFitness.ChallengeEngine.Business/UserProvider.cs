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
            UserChallengeEnrollmentProvider _UserChallengeEnrollmentProvider = new Business.UserChallengeEnrollmentProvider();
            var userchallenge = await _UserChallengeEnrollmentProvider.GetAll();
            ChallengeClubRelationProvider _userChallengeEnrollmentProvider = new ChallengeClubRelationProvider();
            var challengeClubRelationship = await _userChallengeEnrollmentProvider.GetAll();
            var entity = await GetAll();
            var getcheck = (from a in userchallenge
                            join b in challengeClubRelationship
                            on a.ChallengeClubRelationId equals b.ChallengeClubRelationId
                            where a.ChallengeId == _ChallengeId && b.ClubId == _clubId
                            select a);
            var uentity = (from a in entity
                           from b in getcheck
                           where a.UserId != b.UserId
                           && a.RoleId == 3
                           select new Userd
                           {
                               UserId = a.UserId,
                               Name = a.FirstName + " " + a.LastName,
                               UserName = a.UserName,
                               UserRole = a.UserRole.Description
                           }).Distinct();
            return uentity;
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
