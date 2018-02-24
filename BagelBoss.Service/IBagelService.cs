using System;

using BagelBoss.Contracts;

namespace BagelBoss.Service
{
    public interface IBagelService
    {
        Bagel CreateBagel(Boolean toasted);
    }
}
