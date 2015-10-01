﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LayerBusinessEntities;
using LayerDataAccess;

namespace LayerBusinessLogic
{
    public class tb_60colorBL
    {
        tb_60colorDA tablaDA = new tb_60colorDA();

        public bool Insert(string empresaid, tb_60color BE)
        {
            return tablaDA.Insert(empresaid, BE);
        }
        public bool Update(string empresaid, tb_60color BE)
        {
            return tablaDA.Update(empresaid, BE);
        }
        public bool Delete(string empresaid, tb_60color BE)
        {
            return tablaDA.Delete(empresaid, BE);
        }
        public DataSet GetAll(string empresaid, tb_60color BE)
        {
            return tablaDA.GetAll(empresaid, BE);
        }
        public DataSet GetAll_paginacion(string empresaid, tb_60color BE)
        {
            return tablaDA.GetAll_paginacion(empresaid, BE);
        }
        public DataSet GetReport(string empresaid, tb_60color BE)
        {
            return tablaDA.GetReport(empresaid, BE);
        }
        public DataSet GetOne(string empresaid, tb_60color BE)
        {
            return tablaDA.GetOne(empresaid, BE);
        }
    }
}
