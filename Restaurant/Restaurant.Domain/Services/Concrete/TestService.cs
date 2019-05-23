using AutoMapper;
using Restaurant.Database;
using Restaurant.Database.Repositories.Abstract;
using Restaurant.Domain.DTO;
using Restaurant.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Services.Concrete
{
    public class TestService : ITestService
    {
        private ITestRepository _testRepository { get; }

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public IList<TestDto> aa()
        {
            var tests = _testRepository.GetAll();
            return Mapper.Map<IList<TestDto>>(tests);
        }
    }
}
