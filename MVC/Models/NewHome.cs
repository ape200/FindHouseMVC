using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class NewHome
    {
		/// <summary>
		/// 主键Id
		/// </summary>
		public int HomeId { get; set; }
		/// <summary>
		/// 房屋名称
		/// </summary>
		public string HomeName { get; set; }
		/// <summary>
		/// 新房位置
		/// </summary>
		public string HomeAddress { get; set; }
		/// <summary>
		/// 新房户型
		/// </summary>
		public string HomeDesign { get; set; }
		/// <summary>
		/// 新房建筑面积
		/// </summary>
		public string HomeArea { get; set; }
		/// <summary>
		/// 新房价格
		/// </summary>
		public decimal HomePrice { get; set; }
		/// <summary>
		/// HomeMarketType
		/// </summary>
		public int HomeMarketType { get; set; }
	}
}
