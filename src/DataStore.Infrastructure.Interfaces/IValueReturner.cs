﻿namespace Infrastructure.Interfaces
{
    public interface IValueReturner
    {
        void Return<TReturnValue>(TReturnValue returnValue);
    }
}