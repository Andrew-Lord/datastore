﻿namespace Infrastructure.HandlerServices
{
    using System.Collections.Generic;

    using Infrastructure.HandlerServiceInterfaces;

    public class ValueReturner : IValueReturner
    {
        private readonly Dictionary<string, object> returnValues;

        private readonly string eventType;

        public ValueReturner(Dictionary<string, object> returnValues, string eventType)
        {
            this.returnValues = returnValues;
            this.eventType = eventType;
        }

        public void Return<TReturnValue>(TReturnValue returnValue)
        {
            this.returnValues.Add(eventType, returnValue);
        }
    }
}