using System;

namespace Base.Attribute
{
    /// <summary>
    /// Enum �ɃR�[�h����ǉ����܂��B
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class EnumCodeAttribute : System.Attribute
    {
        /// <summary>
        /// �R�[�h
        /// </summary>
        private readonly dynamic _code;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="code"> </param>
        public EnumCodeAttribute(int code)
        {
            _code = code;
        }

        /// <summary>
        /// �R���X�g���N�^
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
