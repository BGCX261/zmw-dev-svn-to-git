using System;

namespace Base.Attribute
{
    /// <summary>
    /// Enum にコード情報を追加します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class EnumCodeAttribute : System.Attribute
    {
        /// <summary>
        /// コード
        /// </summary>
        private readonly dynamic _code;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="code"> </param>
        public EnumCodeAttribute(int code)
        {
            _code = code;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="code"> </param>
        public EnumCodeAttribute(double code)
        {
            _code = code;
        }

        public dynamic Code
        {
            get { return _code; }
        }
    }
}
