﻿
namespace EB.Persistence.SecurityManagers.Navigations;

public class NavigationException : Exception
{
    public NavigationException() { }

    public NavigationException(string message) : base(message) { }

    public NavigationException(string message, Exception innerException) : base(message, innerException) { }
}
