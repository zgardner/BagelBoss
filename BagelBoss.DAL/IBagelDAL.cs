using System;

using BagelBoss.Contracts;

namespace BagelBoss.DAL
{
    public interface IBagelDAL
    {
        Bagel CreateBagel(Boolean toasted);
    }
}
