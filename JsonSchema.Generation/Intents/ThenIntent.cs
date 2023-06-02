﻿using System.Collections.Generic;

namespace Json.Schema.Generation.Intents;

public class ThenIntent : ISchemaKeywordIntent
{
	public IEnumerable<ISchemaKeywordIntent> Subschema { get; }

	/// <summary>
	/// Creates a new <see cref="AdditionalItemsIntent"/> instance.
	/// </summary>
	public ThenIntent(IEnumerable<ISchemaKeywordIntent> subschema)
	{
		Subschema = subschema;
	}

	/// <summary>
	/// Applies the keyword to the <see cref="JsonSchemaBuilder"/>.
	/// </summary>
	/// <param name="builder">The builder.</param>
	public void Apply(JsonSchemaBuilder builder)
	{
		builder.Then(Build(Subschema));
	}

	private static JsonSchema Build(IEnumerable<ISchemaKeywordIntent> subschema)
	{
		var builder = new JsonSchemaBuilder();

		foreach (var intent in subschema)
		{
			intent.Apply(builder);
		}

		return builder;
	}
}