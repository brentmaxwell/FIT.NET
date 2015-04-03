using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;
using theBrent.FitLibrary.FieldTypes;

namespace theBrent.FitLibrary
{
    public class FitField
    {
        public static Dictionary<BaseType, Type> FitBaseTypeMap = new Dictionary<BaseType, Type>()
        {
            {BaseType.ENUM,    typeof(FitField_Enum)    },
            {BaseType.SINT8,   typeof(FitField_SInt8)   },
            {BaseType.UINT8,   typeof(FitField_UInt8)   },
            {BaseType.SINT16,  typeof(FitField_SInt16)  },
            {BaseType.UINT16,  typeof(FitField_UInt16)  },
            {BaseType.SINT32,  typeof(FitField_SInt32)  },
            {BaseType.UINT32,  typeof(FitField_UInt32)  },
            {BaseType.STRING,  typeof(FitField_String)  },
            {BaseType.FLOAT32, typeof(FitField_Float32) },
            {BaseType.FLOAT64, typeof(FitField_Float64) },
            {BaseType.UINT8Z,  typeof(FitField_UInt8z)  },
            {BaseType.UINT16Z, typeof(FitField_UInt16z) },
            {BaseType.UINT32Z, typeof(FitField_UInt32z) },
            {BaseType.BYTE,    typeof(FitField_Byte)    }
        };

        protected internal bool Architecture;

        protected internal byte[] _fieldData;
        public byte FieldDefinitionNumber
        {
            get { return this._fieldData[0]; }
        }

        public int Size
        {
            get { return this._fieldData[1]; }
        }

        public BaseType BaseType
        {
            get { return (BaseType)this._fieldData[2]; }
            set { this._fieldData[2] = (byte)value; }
        }

        public string FieldName;

        protected internal byte[] _value;

        public dynamic Value
        {
            get { return Architecture ? ReverseEndian(this._value) : this._value; }
            set { this._value = value; }
        }

        public dynamic GetValue()
        {
            switch(this.BaseType)
            {
                case BaseType.ENUM:
                    return (this as FitField_Enum).Value;
                case BaseType.SINT8:
                    return (this as FitField_SInt8).Value;
                case BaseType.UINT8:
                    return (this as FitField_UInt8).Value;
                case BaseType.SINT16:
                    return (this as FitField_SInt16).Value;
                case BaseType.UINT16:
                    return (this as FitField_UInt16).Value;
                case BaseType.SINT32:
                    return (this as FitField_SInt32).Value;
                case BaseType.UINT32:
                    return (this as FitField_UInt32).Value;
                case BaseType.STRING:
                    return (this as FitField_String).Value;
                case BaseType.FLOAT32:
                    return (this as FitField_Float32).Value;
                case BaseType.FLOAT64:
                    return (this as FitField_Float64).Value;
                case BaseType.UINT8Z:
                    return (this as FitField_UInt8z).Value;
                case BaseType.UINT16Z:
                    return (this as FitField_UInt16z).Value;
                case BaseType.UINT32Z:
                    return (this as FitField_UInt32z).Value;
                case BaseType.BYTE:
                    return (this as FitField_Byte).Value;
                default:
                    return Value;
            }
        }

        public object GetDynamicValue()
        {
            CallSite<Func<CallSite, object, object>> site
                = CallSite<Func<CallSite, object, object>>.Create
                (Binder.GetMember(CSharpBinderFlags.None, "Value",
                 typeof(FitField), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
            return site.Target(site, this);
        }

        public FitField(byte[] fieldData)
        {
            this._fieldData = fieldData;
            this._value = new byte[this.Size];
        }

        public FitField(byte[] fieldData, bool Architecture) : this(fieldData)
        {
            this.Architecture = Architecture;
            if (this.Architecture)
            {
                Array.Reverse(this._fieldData);
            }
        }

        public FitField(FitField field) : this(field._fieldData)
        {
            this._value = field._value;
        }

        public static FitField FitFieldFactory(FitField field)
        {
            FitField f = (FitField)Activator.CreateInstance(field.GetType(),field._fieldData);
            f.FieldName = field.FieldName;
            return f;
        }

        public static FitField FitFieldFactory(byte[] fieldData)
        {
            return (FitField)Activator.CreateInstance(FitBaseTypeMap[(BaseType)fieldData[2]],fieldData);
        }

        public static FitField FitFieldFactory(byte[] fieldData, bool Architecture)
        {
            FitField f = (FitField)Activator.CreateInstance(FitBaseTypeMap[(BaseType)fieldData[2]], fieldData);
            f.Architecture = Architecture;
            return f;
        }

        public static FitField FitFieldFactory(MessageNumber number, byte[] fieldData)
        {
            if (FitProfile.MessageMap.ContainsKey(number))
            {
                if (FitProfile.MessageMap[number].Fields.ContainsKey(fieldData[0]))
                {
                    FitField f = (FitField)Activator.CreateInstance(FitProfile.MessageMap[number].Fields[fieldData[0]].FieldType, fieldData);
                    f.FieldName = FitProfile.MessageMap[number].Fields[fieldData[0]].Name;
                    return f;
                }
            }
            return FitFieldFactory(fieldData);
        }

        public static FitField FitFieldFactory(MessageNumber number, byte[] fieldData, bool Architecture)
        {
            if (FitProfile.MessageMap.ContainsKey(number))
            {
                if (FitProfile.MessageMap[number].Fields.ContainsKey(fieldData[0]))
                {
                    FitField f = (FitField)Activator.CreateInstance(FitProfile.MessageMap[number].Fields[fieldData[0]].FieldType, fieldData);
                    f.Architecture = Architecture;
                    f.FieldName = FitProfile.MessageMap[number].Fields[fieldData[0]].Name;
                    return f;
                }
            }
            return FitFieldFactory(fieldData);
        }

        public static byte[] ReverseEndian(byte[] data)
        {
            Array.Reverse(data);
            return data;
        }
    }

    public class FitField_Enum : FitField
    {
        public const byte INVALID_VALUE = 0xFF;
        public new byte? Value
        {
            get { return (this._value[0] == INVALID_VALUE) ? new byte?() : this._value[0]; }
        }
        public FitField_Enum(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.ENUM;
        }
    }

    public class FitField_SInt8 : FitField
    {
        public const sbyte INVALID_VALUE = 0x7F;
        public new sbyte? Value
        {
            get { return (this._value[0] == INVALID_VALUE) ? new sbyte?() : (sbyte)this._value[0]; }
        }
        public FitField_SInt8(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.SINT8;
        }
    }

    public class FitField_UInt8 : FitField
    {
        public const byte INVALID_VALUE = 0xFF;
        public new byte? Value
        {
            get { return (this._value[0] == INVALID_VALUE) ? new byte?() : this._value[0]; }
        }
        public FitField_UInt8(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.UINT8;
        }
    }

    public class FitField_SInt16 : FitField
    {
        public const short INVALID_VALUE = 0x7FFF;
        public new short? Value
        {
            get { return (BitConverter.ToInt16(this._value, 0) == INVALID_VALUE) ? new short?() : BitConverter.ToInt16(this._value, 0); }
        }
        public FitField_SInt16(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.SINT16;
        }
    }

    public class FitField_UInt16 : FitField
    {
        public const ushort INVALID_VALUE = 0xFFFF;
        public new ushort? Value
        {
            get { return (BitConverter.ToUInt16(this._value, 0) == INVALID_VALUE) ? new ushort?() : BitConverter.ToUInt16(this._value, 0); }
        }
        public FitField_UInt16(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.UINT16;
        }
    }

    public class FitField_SInt32 : FitField
    {
        public const int INVALID_VALUE = 0x7FFFFFFF;
        public new int? Value
        {
            get { return (BitConverter.ToInt32(this._value, 0) == INVALID_VALUE) ? new int?() : BitConverter.ToInt32(this._value, 0); }
        }
        public FitField_SInt32(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.SINT32;
        }
    }

    public class FitField_UInt32 : FitField
    {
        public const uint INVALID_VALUE = 0xFFFFFFFF;
        public new uint? Value
        {
            get { return (BitConverter.ToUInt32(this._value, 0) == INVALID_VALUE) ? new uint?() : BitConverter.ToUInt32(this._value, 0); }
        }
        public FitField_UInt32(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.UINT32;
        }
    }

    public class FitField_String : FitField
    {
        public const string INVALID_VALUE = null;
        public new string Value
        {
            get { return Encoding.UTF8.GetString(this._value); }
        }
        public FitField_String(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.STRING;
        }
    }

    public class FitField_Float32 : FitField
    {
        public const float INVALID_VALUE = 0xFFFFFFFF;
        public new float? Value
        {
            get { return (BitConverter.ToSingle(this._value, 0) == INVALID_VALUE) ? new float?() : BitConverter.ToSingle(this._value, 0); }
        }
        public FitField_Float32(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.FLOAT32;
        }
    }

    public class FitField_Float64 : FitField
    {
        public const double INVALID_VALUE = 0xFFFFFFFFFFFFFFFF;
        public new double? Value
        {
            get { return (BitConverter.ToDouble(this._value, 0) == INVALID_VALUE) ? new double?() : BitConverter.ToDouble(this._value, 0); }
        }
        public FitField_Float64(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.FLOAT64;
        }
    }

    public class FitField_UInt8z : FitField
    {
        public const byte INVALID_VALUE = 0x00;
        public new byte? Value
        {
            get { return (this._value[0] == INVALID_VALUE) ? new byte?() : this._value[0]; }
        }
        public FitField_UInt8z(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.UINT8Z;
        }
    }

    public class FitField_UInt16z : FitField
    {
        public const ushort INVALID_VALUE = 0x0000;
        public new ushort? Value
        {
            get { return (BitConverter.ToUInt16(this._value, 0) == INVALID_VALUE) ? new ushort?() : BitConverter.ToUInt16(this._value, 0); }
        }
        public FitField_UInt16z(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.UINT16Z;
        }
    }

    public class FitField_UInt32z : FitField
    {
        public const uint INVALID_VALUE = 0x00000000;
        public new uint? Value
        {
            get { return (BitConverter.ToUInt32(this._value, 0) == INVALID_VALUE) ? new uint?() : BitConverter.ToUInt32(this._value, 0); }
        }
        public FitField_UInt32z(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.UINT32Z;
        }
    }

    public class FitField_Byte : FitField
    {
        public const byte INVALID_VALUE = 0xFF;
        public new byte? Value
        {
            get { return (this._value[0] == INVALID_VALUE) ? new byte?() : this._value[0]; }
        }
        public FitField_Byte(byte[] fieldData) : base(fieldData)
        {
            this.BaseType = FitLibrary.BaseType.BYTE;
        }
    }

    public class FitField_Bool : FitField_Byte
    {
        public new bool? Value
        {
            get { return (base.Value > 0); }
        }
        public FitField_Bool(byte[] fieldData) : base(fieldData) { }
    }
}
