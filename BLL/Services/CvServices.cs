using AutoMapper;
using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class CvServices
    {
        public static bool CreateCV(int userId)
        {
            var cvdto = new CvDTO
            {
                userId = userId
            };

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CvDTO, CV>();
            });
            var mapper = new Mapper(config);

            var cv = mapper.Map<CV>(cvdto);
            var rtn = DataAccessFactory.CvDataAccess().CreateCV(cv);
            return rtn;
        }
    }
}
