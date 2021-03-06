﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public interface Required<anyClass>
    {
        void create(anyClass obj);
        void delete(anyClass obj);
        void update(anyClass obj);
        anyClass find(long obj);
        List<anyClass> findAll();
    }
}
