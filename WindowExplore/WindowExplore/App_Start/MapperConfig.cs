using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using WindowExplore.Profiles;
using WindowExplore.ViewModel;

namespace WindowExplore.App_Start
{
    public static class MapperConfig
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfigurationExpression();
            mapperConfig.AddProfile(typeof(ManagementProfile));
            var config = new MapperConfiguration(mapperConfig);

            return config.CreateMapper();
        }
           
    }
}