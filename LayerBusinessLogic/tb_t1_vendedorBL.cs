﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_t1_vendedorBL
    {
        tb_t1_vendedorDA tablaDA = new tb_t1_vendedorDA();

        public bool Insert(string empresaid, tb_t1_vendedor BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_t1_vendedor BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_t1_vendedor BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_t1_vendedor BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, string vendorid)
        {
            return tablaDA.GetOne(empresaid, vendorid);
        }
    }
}