using AutoFixture;
using Moq;
using NUnit.Framework;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.DAL.Entities;
using SocialWeb.DAL.Repositories;

namespace SocialWeb.BLL.Tests.Services
{
    [TestFixture]
    public class FriendRequestServiceTests
    {
        Mock<IUserRepository> _userRepositoryMock;
        Mock<IFriendRepository> _friendRepositoryMock;
        Mock<IFriendRequestRepository> _friendRequestRepositoryMock;
        Fixture _fixture;

        [OneTimeSetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _friendRepositoryMock = new Mock<IFriendRepository>();
            _friendRequestRepositoryMock = new Mock<IFriendRequestRepository>();
            _fixture = new Fixture();
        }

        [Test]
        public void FindInputRequest_MustReturnCorrectValue()
        {
            int userId = 5;
            
            var friendInputRequestEntities = new List<FriendRequestEntity>();
            for (int i = 0; i < 3; i++)
                friendInputRequestEntities.Add(_fixture.Build<FriendRequestEntity>()
                    .With(x => x.user_id, i + 1).With(x => x.requested_user_id, userId).Create());

            var userSenderEntity = _fixture.Build<UserEntity>()
                .With(x => x.id, 2).With(x => x.email, "test").Create();

            var friendRequestSendingData = new FriendRequestSendingData()
            {
                SearchEmail = userSenderEntity.email, UserId = userId
            };

            _userRepositoryMock.Setup(x => x.FindByEmail("test")).Returns(userSenderEntity);
            _friendRequestRepositoryMock.Setup(x => x.FindAllByRequestedUserId(userId))
                .Returns(friendInputRequestEntities);

            var friendServiceTest = new FriendRequestService(_friendRequestRepositoryMock.Object,
                _friendRepositoryMock.Object, _userRepositoryMock.Object);

            var friendsRequestInputTest = friendServiceTest.FindInputRequest(friendRequestSendingData);
            Assert.That(friendsRequestInputTest.Id == friendInputRequestEntities[1].id);
        }

        [Test]
        public void FindOutputRequest_MustReturnCorrectValue()
        {
            int userId = 12;

            var friendOutputRequestEntities = new List<FriendRequestEntity>();
            for (int i = 0; i < 3; i++)
                friendOutputRequestEntities.Add(_fixture.Build<FriendRequestEntity>()
                    .With(x => x.requested_user_id, i + 1).With(x => x.user_id, userId).Create());

            var userRecipientEntity = _fixture.Build<UserEntity>()
                .With(x => x.id, 3).With(x => x.email, "test").Create();

            var friendRequestSendingData = new FriendRequestSendingData()
            {
                SearchEmail = userRecipientEntity.email, UserId = userId
            };

            _userRepositoryMock.Setup(x => x.FindByEmail("test")).Returns(userRecipientEntity);
            _friendRequestRepositoryMock.Setup(x => x.FindAllByUserId(userId))
                .Returns(friendOutputRequestEntities);

            var friendServiceTest = new FriendRequestService(_friendRequestRepositoryMock.Object,
                _friendRepositoryMock.Object, _userRepositoryMock.Object);

            var friendRequestOutputTest = friendServiceTest.FindOutputRequest(friendRequestSendingData);
            Assert.That(friendRequestOutputTest.Id == friendOutputRequestEntities[2].id);
        }

        [Test]
        public void SendRequest_NotMustThrowException()
        {
            IEnumerable<FriendRequestEntity> requestEntities = new List<FriendRequestEntity>();
            FriendEntity? friendEntityTest = null;
            int userId = 2;

            var userRecipientEntityTest = _fixture.Build<UserEntity>()
                .With(x => x.id, 44).With(x => x.email, "test").Create();

            var friendRequestSendingData = new FriendRequestSendingData()
            {
                SearchEmail = userRecipientEntityTest.email, UserId = userId
            };

            var creatingFriendRequestEntityTest = new FriendRequestEntity()
            {
                user_id = userId, requested_user_id = userRecipientEntityTest.id
            };

            _userRepositoryMock.Setup(x => x.FindByEmail("test")).Returns(userRecipientEntityTest);
            _friendRequestRepositoryMock.Setup(x => x.FindAllByUserId(userId))
                .Returns(requestEntities);
            _friendRequestRepositoryMock.Setup(x => x.FindAllByRequestedUserId(userId))
                .Returns(requestEntities);
            _friendRepositoryMock.Setup(x => x.FindByUserIdAndFriendId(userId, userRecipientEntityTest.id))
                .Returns(friendEntityTest);
            _friendRequestRepositoryMock.Setup(x => x.Create(creatingFriendRequestEntityTest)).Returns(1);

            var friendRequestServiceTest = new FriendRequestService(_friendRequestRepositoryMock.Object,
                _friendRepositoryMock.Object, _userRepositoryMock.Object);
            Assert.DoesNotThrow(() => friendRequestServiceTest.SendRequest(friendRequestSendingData));
        }

        [Test]
        public void FindAllInputRequestByUserId_MustReturnCorrectValue()
        {
            int userId = 4;

            var friendRequestEntities = new List<FriendRequestEntity>();
            for (int i = 0; i < 3; i++)
                friendRequestEntities.Add(_fixture.Build<FriendRequestEntity>()
                    .With(x => x.user_id, i + 1).With(x => x.requested_user_id, userId).Create());           

            var userEntities = new List<UserEntity>();
            for (int i = 0; i < 3; i++)
                userEntities.Add(_fixture.Build<UserEntity>().With(x => x.id, i + 1).Create());

            _friendRequestRepositoryMock.Setup(x => x.FindAllByRequestedUserId(userId)).Returns(friendRequestEntities);

            for(int i = 0; i < 3; i++)
                _userRepositoryMock.Setup(x => x.FindById(i + 1)).Returns(userEntities[i]);

            var friendRequestServiceTest = new FriendRequestService(_friendRequestRepositoryMock.Object,
                _friendRepositoryMock.Object, _userRepositoryMock.Object);

            var friendRequests = friendRequestServiceTest.FindAllInputRequestByUserId(userId);

            foreach (var userEntity in userEntities)
                Assert.That(friendRequests.Any(x => x.Email == userEntity.email
                                            && x.FirstName == userEntity.firstname
                                            && x.LastName == userEntity.lastname));
        }

        [Test]
        public void FindAllOutputRequestByUserId_MustReturnCorrectValue()
        {
            int userId = 15;

            var friendRequestEntities = new List<FriendRequestEntity>();
            for (int i = 0; i < 3; i++)
                friendRequestEntities.Add(_fixture.Build<FriendRequestEntity>()
                    .With(x => x.requested_user_id, i + 1).With(x => x.user_id, userId).Create());

            var userEntities = new List<UserEntity>();
            for (int i = 0; i < 3; i++)
                userEntities.Add(_fixture.Build<UserEntity>().With(x => x.id, i + 1).Create());

            _friendRequestRepositoryMock.Setup(x => x.FindAllByUserId(userId)).Returns(friendRequestEntities);

            for(int i = 0; i < 3; i++)
                _userRepositoryMock.Setup(x => x.FindById(i + 1)).Returns(userEntities[i]);

            var friendRequestServiceTest = new FriendRequestService(_friendRequestRepositoryMock.Object,
                _friendRepositoryMock.Object, _userRepositoryMock.Object);

            var friendRequests = friendRequestServiceTest.FindAllOutputRequestByUserId(userId);

            foreach (var userEntity in userEntities)
                Assert.That(friendRequests.Any(x => x.Email == userEntity.email
                                            && x.FirstName == userEntity.firstname
                                            && x.LastName == userEntity.lastname));

        }

        [Test]
        public void DeleteRequest_NotMustThrowException()
        {
            int id = 25;

            var friendRequestTest = _fixture.Build<FriendRequestEntity>().With(x => x.id, id).Create();

            _friendRequestRepositoryMock.Setup(x => x.FindById(id)).Returns(friendRequestTest);
            _friendRequestRepositoryMock.Setup(x => x.Delete(id)).Returns(1);

            var friendRequestServiceTest = new FriendRequestService(_friendRequestRepositoryMock.Object,
                _friendRepositoryMock.Object, _userRepositoryMock.Object);

            Assert.DoesNotThrow(() => friendRequestServiceTest.DeleteRequest(id));
        }
    }
}
