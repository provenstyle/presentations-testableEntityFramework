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
        };

        Because of = () =>
        {
        };

        It returns_repository_data = () => {};

        static Mock<IRepository> _repository;
        static IEnumerable<Talk> _talks;
    }

    public class when_mocking_the_datacontext
    {
        Establish context = () =>
        {
            
        };

        Because of = () =>
        {
          
        };

        It returns_datacontext_data = () => {};

        static Repository _repository;
        static IEnumerable<Talk> _talks;
    }

    public class when_spying_on_the_dataContext
    {
        Establish context = () =>
        {
            
        };

        Because of = () =>
        {

        };

        It should_be_called_once = () =>
        {
            
        };

        static Mock<IDataContext> _dataContext;
        static Repository _repository;
    }

    public class when_using_in_memory_datacontext
    {
        Establish context = () =>
        {
        };

        Because of = () =>
        {
        };

        It should_return_inmemory_data = () =>
        {
        };
        
        static Repository _repository;
        static IEnumerable<Talk> _talks;
    }

    public class when_creating_vm
    {
        Establish context = () =>
        {
        };

        Because of = () =>
        {
        };

        It should_have_accepted_talks = () =>
        {
        };
        
        It should_have_submitted_talks = () =>
        {
        };

        static TalksModel _model;
        static TalkViewModel _vm;
    }
}
