using LifetimeFitness.ChallengeEngine.Core;
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

        public void Insert(User _Challenge)
        {
            userRepository.Insert(_Challenge);
        }

        public void Update(User _Challenge)
        {
            userRepository.Update(_Challenge);
        }

        public void Delete(User _Challenge)
        {
            userRepository.Delete(_Challenge);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await userRepository.GetAll();
        }

        public async Task<User> GetById(int _id)
        {
            return await userRepository.GetById(_id);
        }

        public async Task<ICollection<User>> FindBy(Expression<Func<User, bool>> predicate)
        {
            return await userRepository.FindBy(predicate);
        }

        public async Task<IEnumerable<User>> GetAllBy(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null)
        {
            return await userRepository.GetAllBy(filter, orderBy);
        }

        public string HashPassword(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
        //public async Task<User> Login(string userName, string password)
        //{
        //    string hashPassword = HashPassword(password);
        //    var entity = await FindBy(u => u.UserName == userName && u.Password == hashPassword);
        //    if (entity != null)
        //    {
                
        //        return entity;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


    }
}
