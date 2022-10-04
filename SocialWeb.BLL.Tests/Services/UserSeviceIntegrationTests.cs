using NUnit.Framework;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;

namespace SocialWeb.BLL.Tests.Services
{
    [TestFixture]
    public class UserSeviceIntegrationTests
    {
        private UserService userServiceTest;
        private UserRegistrationData userRegistrationDataTest;

        [OneTimeSetUp]
        public void SetUp()
        {
            userServiceTest = new UserService();
            userRegistrationDataTest = new UserRegistrationData()
            {                
                FirstName = "test",
                LastName = "test",
                Password = "password",
                Email = "test@gmail.com"
            };
        }

        [Test]
        public void FindByIdAndFindByEmail_NotMustThrowException()
        {
            userServiceTest.Register(userRegistrationDataTest);

            User? userTestFindByEmail = null; 
            Assert.DoesNotThrow(() => userTestFindByEmail = userServiceTest.FindByEmail(userRegistrationDataTest.Email));
            Assert.NotNull(userTestFindByEmail);

            var allUsersAfterRegisterNewUser = userServiceTest.GetAllUsers();
            CollectionAssert.Contains(allUsersAfterRegisterNewUser, userTestFindByEmail);

            User? userTestFindById = null;
            Assert.DoesNotThrow(() => userTestFindById = userServiceTest.FindById(userTestFindByEmail.Id));
            Assert.NotNull(userTestFindById);

            Assert.AreEqual(userTestFindById, userTestFindByEmail);

            userServiceTest.Delete(userTestFindById);

            var allUsersAfterDeletingTestUser = userServiceTest.GetAllUsers();
            CollectionAssert.DoesNotContain(allUsersAfterDeletingTestUser, userTestFindById);
        }

        [Test]
        public void Authenticate_NotMustThrowException()
        {
            userServiceTest.Register(userRegistrationDataTest);

            var userAuthenticateDataTest = new UserAuthenticationData()
            {
                Email = userRegistrationDataTest.Email,
                Password = userRegistrationDataTest.Password
            };

            User? userTest = null;
            Assert.DoesNotThrow(() => userTest = userServiceTest.Authenticate(userAuthenticateDataTest));
            Assert.NotNull(userTest);

            userServiceTest.Delete(userTest);

            var allUsersAfterDeletingTestUser = userServiceTest.GetAllUsers();
            CollectionAssert.DoesNotContain(allUsersAfterDeletingTestUser, userTest);
        }

        [Test]
        public void Update_MustReplaceValueInBase()
        {
            userServiceTest.Register(userRegistrationDataTest);

            var userTest = userServiceTest.FindByEmail(userRegistrationDataTest.Email);

            var allUsersAfterRegisterNewUser = userServiceTest.GetAllUsers();
            CollectionAssert.Contains(allUsersAfterRegisterNewUser, userTest);

            var userUpdateTest = userTest.Clone();

            userUpdateTest.FirstName = "updateTest";
            userUpdateTest.LastName = "updateTest";
            userUpdateTest.Photo = "Test";
            userUpdateTest.FavoriteBook = "Test";
            userUpdateTest.FavoriteMovie = "Test";

            userServiceTest.Update(userUpdateTest);

            var allUsersAfterUpdatingTestUser = userServiceTest.GetAllUsers();
            CollectionAssert.Contains(allUsersAfterUpdatingTestUser, userUpdateTest);
            CollectionAssert.DoesNotContain(allUsersAfterUpdatingTestUser, userTest);

            userServiceTest.Delete(userUpdateTest);

            var allUsersAfterDeletingTestUser = userServiceTest.GetAllUsers();
            CollectionAssert.DoesNotContain(allUsersAfterDeletingTestUser, userUpdateTest);
        }
    }
}