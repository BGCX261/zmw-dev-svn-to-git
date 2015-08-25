
using System;

namespace Base.Attribute
{
    /// <summary>
    /// Enum に名前やメッセージ情報を追加します。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class EnumStringAttribute : System.Attribute
    {
        /// <summary>
        /// 名前
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// メッセージ
        /// </summary>
        private readonly string _message;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        public EnumStringAttribute(string name)
            : this(name, string.Empty)
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public EnumStringAttribute(string name, string message)
        {
            this._name = name;
            this._message = message;
        }

        /// <summary>
        /// 名前を取得します。
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// メッセージを取得します。
        /// </summary>
        public string Message
        {
            get { return _message; }
        }
    }
}
