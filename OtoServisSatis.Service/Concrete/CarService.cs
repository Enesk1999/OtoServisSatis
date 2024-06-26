﻿using OtoServisSatis.Data;
using OtoServisSatis.Data.Concrete;
using OtoServisSatis.Service.Abstract;

namespace OtoServisSatis.Service.Concrete
{
    public class CarService : CarRepository, ICarService
    {
        public CarService(OtoDatabaseContext context) : base(context)
        {
        }
    }
}
