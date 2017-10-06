using System;
using Dtos;
using Datas;

namespace Services
{
    public class GreetingService
    {
        private Repository _repository;

        //注入repository
        public GreetingService(Repository repository)
        {
            _repository = repository;
        }

        public virtual GreetingDto GetGreetings(int id=0,string name = "")
        {
            var data = _repository.GetGreeting(id);
            return new GreetingDto()
            {
                Greetings = $"{data.Greetings} {name}!"
            };
        }

    }
}
