﻿using System.Collections.Generic;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Sql.Queries.Builders.Core {
    /// <summary>
    /// 参数管理器
    /// </summary>
    public class ParameterManager : IParameterManager {
        /// <summary>
        /// 参数集合
        /// </summary>
        private readonly IDictionary<string, object> _params;

        /// <summary>
        /// 初始化参数管理器
        /// </summary>
        public ParameterManager() {
            _params = new Dictionary<string, object>();
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        public IDictionary<string, object> GetParams() {
            return _params;
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="operator">运算符</param>
        public void Add( string name, object value, Operator @operator ) {
            _params.Add( name, GetValue( value, @operator ) );
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private object GetValue( object value, Operator @operator ) {
            switch( @operator ) {
                case Operator.Contains:
                    return $"%{value}%";
                case Operator.Starts:
                    return $"{value}%";
                case Operator.Ends:
                    return $"%{value}";
                default:
                    return value;
            }
        }
    }
}
