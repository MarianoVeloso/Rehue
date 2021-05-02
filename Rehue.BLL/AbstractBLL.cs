﻿using Rehue.BE;
using Rehue.BE.Interfaces;
using System;
using System.Collections.Generic;

namespace Rehue.BLL
{
    public abstract class AbstractBLL<T> : ICrud<T> where T : IEntity
    {
        protected ICrud<T> _crud;

        public void Delete(T entity)
        {
            _crud.Delete(entity);
        }

        public IList<T> GetAll()
        {
            return _crud.GetAll();
        }

        public T GetById(Guid id)
        {
            return _crud.GetById(id);
        }

        public void Save(T entity)
        {
            _crud.Save(entity);
        }
    }
}
