﻿using LAMS.DataAccess.Common.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAMS.DataAccess.Common.Models.Work
{
  public  class DocumentDb
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата сохранения текста в базу
        /// </summary>
        public DateTime? SavedDate { get; set; } = DateTime.Now;

        public string PersonalInfoId { get; set; }

        public virtual PersonalInfoDb PersonalInfos { get; set; }

        /// <summary>
        /// Расширение файла
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Позиция текста при его передаче
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Сам текст
        /// </summary>
        public byte[] Text { get; set; }

    }
}
