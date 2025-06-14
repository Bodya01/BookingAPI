﻿namespace BookingAPI.Application.Exceptions.Abstractions
{
    public abstract class ApplicationException : Exception
    {
        protected ApplicationException(string? message) : base(message)
        {
        }
    }
}