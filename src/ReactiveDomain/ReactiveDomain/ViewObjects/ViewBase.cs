﻿// ReSharper disable MemberCanBePrivate.Global

using ReactiveDomain.Domain;

namespace ReactiveDomain.ViewObjects
{
    public abstract class ViewBase
    {
        protected readonly IRepository Repo;
        protected ViewBase(IRepository repo)
        {
            Repo = repo;
        }
    }
}
