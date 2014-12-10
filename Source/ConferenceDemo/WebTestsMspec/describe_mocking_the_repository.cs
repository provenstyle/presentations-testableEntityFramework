using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using Data.Queries;
using Highway.Data;
using Highway.Data.Contexts;
using Machine.Specifications;
using Moq;
using Web.Models;
using It = Machine.Specifications.It;

// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToLambdaExpression
namespace WebTestsMspec
{
    public class when_mocking_the_repository
    {
        Establish context = () =>
        {
            _repository = new Mock<IRepository>();
            _repository
                .Setup(x => x.Find(Moq.It.IsAny<TalksBySpeakerId>()))
                .Returns(new List<Talk>
                        {
                            new Talk()
                        });
        };

        Because of = () =>
        {
            _talks = _repository.Object.Find(new TalksBySpeakerId(1));
        };

        It returns_repository_data = () => _talks.Count().ShouldEqual(1);

        static Mock<IRepository> _repository;
        static IEnumerable<Talk> _talks;
    }

    public class when_mocking_the_datacontext
    {
        Establish context = () =>
        {
            var dataContext = new Mock<IDataContext>();
            dataContext.Setup(x => x.AsQueryable<Talk>())
                .Returns(new List<Talk>
                {
                    new Talk(),
                    new Talk()
                }.AsQueryable());

                _repository = new Repository(dataContext.Object);
        };

        Because of = () =>
        {
            _talks = _repository.Find(new AllTalks());
        };

        It returns_datacontext_data = () => _talks.Count().ShouldEqual(2);

        static Repository _repository;
        static IEnumerable<Talk> _talks;
    }

    public class when_spying_on_the_dataContext
    {
        Establish context = () =>
        {
            _dataContext = new Mock<IDataContext>();
            _dataContext.Setup(x => x.AsQueryable<Talk>())
                .Returns(new List<Talk>
                {
                    new Talk(),
                    new Talk()
                }.AsQueryable());

            _dataContext
                .Setup(x => x.Commit());

            _repository = new Repository(_dataContext.Object);
        };

        Because of = () => _repository.Context.Commit();

        It should_be_called_once = () => _dataContext.Verify(x=>x.Commit(), Times.Once);

        static Mock<IDataContext> _dataContext;
        static Repository _repository;
    }

    public class when_using_in_memory_datacontext
    {
        Establish context = () =>
        {
            var dataContext = new InMemoryDataContext();
            dataContext.Add(new Talk());
            dataContext.Add(new Talk());
            _repository = new Repository(dataContext);
        };

        Because of = () =>
        {
            _talks = _repository.Find(new AllTalks());
        };

        It should_return_inmemory_data = () => _talks.Count().ShouldEqual(2);
        
        static Repository _repository;
        static IEnumerable<Talk> _talks;
    }

    public class when_creating_vm
    {
        Establish context = () =>
        {
            var dataContext = new InMemoryDataContext();
            var speaker = new Speaker {Id = 7};
            dataContext.Add(new Talk {Speaker = speaker, Accepted = false});
            dataContext.Add(new Talk {Speaker = speaker, Accepted = false});
            dataContext.Add(new Talk {Speaker = speaker, Accepted = true});

            var repository = new Repository(dataContext);
            _model = new TalksModel(repository);
        };

        Because of = () =>
        {
            _vm = _model.GetTalks(7);
        };

        It should_have_accepted_talks = () => _vm.AcceptedTalks.Count().ShouldEqual(1);
        It should_have_submitted_talks = () => _vm.SubmittedTalks.Count().ShouldEqual(2);

        static TalksModel _model;
        static TalkViewModel _vm;
    }
}
