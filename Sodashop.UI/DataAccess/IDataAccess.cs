﻿using Sodashop.DTO.DTOs;

namespace Sodashop.UI.DataAccess
{
    public interface IDataAccess<T>
    {
        List<T> GetAll();
    }
}
