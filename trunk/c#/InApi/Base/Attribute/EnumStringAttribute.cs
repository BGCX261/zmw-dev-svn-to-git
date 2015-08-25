
using System;

namespace Base.Attribute
{
    /// <summary>
    /// Enum �ɖ��O�⃁�b�Z�[�W����ǉ����܂��B
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class EnumStringAttribute : System.Attribute
    {
        /// <summary>
        /// ���O
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        private readonly string _message;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="name"></param>
        public EnumStringAttribute(string name)
            : this(name, string.Empty)
        {
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public EnumStringAttribute(string name, string message)
        {
            this._name = name;
            this._message = message;
        }

        /// <summary>
        /// ���O���擾���܂��B
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// ���b�Z�[�W���擾���܂��B
        /// </summary>
        public string Message
        {
            get { return _message; }
        }
    }
}
