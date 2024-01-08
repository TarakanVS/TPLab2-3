using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class RepositoryTests
    {
        private IMapper _mapper;

        public RepositoryTests(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
