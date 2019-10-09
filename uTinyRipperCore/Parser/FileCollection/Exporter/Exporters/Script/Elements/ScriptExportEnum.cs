using System;
using System.Collections.Generic;
using System.IO;

namespace uTinyRipper.Exporters.Scripts
{
	public abstract class ScriptExportEnum : ScriptExportType
	{
		public sealed override void Export(TextWriter writer, int intent)
		{
			writer.WriteIndent(intent);
			writer.Write("{0} enum {1}", Keyword, TypeName);
			if (Base != null && Base.TypeName != MonoUtils.IntName)
			{
				writer.Write(" : {0}", Base.TypeName);
			}
			writer.WriteLine();

			writer.WriteIndent(intent++);
			writer.WriteLine('{');
			
			foreach (ScriptExportField field in Fields)
			{
				field.ExportEnum(writer, intent);
			}

			writer.WriteIndent(--intent);
			writer.WriteLine('}');
		}

		public sealed override bool HasMember(string name)
		{
			throw new NotSupportedException();
		}

		public sealed override bool IsEnum => true;
		public sealed override IReadOnlyList<ScriptExportProperty> Properties { get; } = new ScriptExportProperty[0];
		public sealed override IReadOnlyList<ScriptExportMethod> Methods { get; } = new ScriptExportMethod[0];

		protected sealed override bool IsStruct => throw new NotSupportedException();
		protected sealed override bool IsSerializable => false;
	}
}
