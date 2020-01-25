using Iris.BusinessLayer.Abstract;
using Iris.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace Iris.XunitTest
{
    public class UnitTests
    {
        private readonly IPersonService _personService;

        public UnitTests(IPersonService personService)
        {
            _personService = personService;
        }

        [Fact]
        public void Control()
        {
            Assert.Empty(string.Empty);
        }
        [Fact]
        public void Get_Person_List()
        {
            List<Person> personList = _personService.GetList();
            Assert.NotNull(personList);
        }
        [Fact]
        public void Add_New_Person()
        {
            Person result = _personService.Add(new Person()
            {
                Age = 24,
                AtCreated = DateTime.Now,
                IsDeleted = false,
                Name = "Muhsin Cem",
                Surname = "Kütükcü"
            });
            if (result.Id > 0)
                Assert.True(true);
            else
                Assert.True(false);
        }
    }
}
