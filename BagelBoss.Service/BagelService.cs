using System;

using BagelBoss.Contracts;
using BagelBoss.DAL;

namespace BagelBoss.Service
{
    public class BagelService : IBagelService
    {
        private readonly IBagelDAL bagelDAL;

        public BagelService(IBagelDAL bagelDAL)
        {
            this.bagelDAL = bagelDAL;
        }

        public Bagel CreateBagel(Boolean toasted)
        {
            return bagelDAL.CreateBagel(toasted);
        }
    }
}
