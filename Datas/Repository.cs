using System;
using Microsoft.Extensions.Configuration;
using Domains;
using System.Linq;

namespace Datas
{
    //Demo仓储
    public class Repository
    {
        private IConfigurationRoot _configuration { get; }
        //数据读取字符串
        private string _readConnStr => _configuration.GetConnectionString("read");
        //数据写入字符串
        private string _writeConnStr => _configuration.GetConnectionString("write");
       
        private VueDbContext _db;

        //注入IConfigurationRoot
        public Repository(IConfigurationRoot configuration,VueDbContext db)
        {
            _configuration = configuration;
            _db=db;
        }
        
         //通过id查询第一条记录并返回entity
        public virtual Greeting GetGreeting(int id)
        {
            return _db.Greetings.First(p=>p.Id==id);
        }

    }
}
