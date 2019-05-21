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
        private IMapper __mapper { get; }

        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            __mapper = mapper;
        }


        public IList<TestDto> aa()
        {
            var tests = _testRepository.GetAll();
            return __mapper.Map<IList<TestDto>>(tests);
        }
    }
}
