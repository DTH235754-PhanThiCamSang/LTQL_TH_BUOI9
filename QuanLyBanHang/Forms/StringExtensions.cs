using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Forms
{
    public static class StringExtensions
    {

        public static string GenerateSlug(this string phrase) // PHẢI có chữ this ở đây
        {
            if (string.IsNullOrEmpty(phrase)) return "no-name";
            return phrase.ToLower().Replace(" ", "-");
        }
    }
    }
