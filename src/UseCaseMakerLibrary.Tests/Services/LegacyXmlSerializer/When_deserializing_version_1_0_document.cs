using System;
using System.IO;
using Machine.Specifications;
using UseCaseMakerLibrary.Contracts;

namespace UseCaseMakerLibrary.Tests.Services.LegacyXmlSerializer
{
    [Subject(typeof(UseCaseMakerLibrary.Services.LegacyXmlSerializer))]
    public class When_deserializing_version_1_0_document
    {
        private const string SavedDocument =
            @"<?xml version=""1.0"" encoding=""UTF-8""?>
<UCM-Document Version=""1.0"">
  <Model Type=""UseCaseMakerLibrary.Model"" UniqueID=""32e43cb0-8050-4597-8a61-dcba1496888d"" Name=""Test"" ID=""1"" Prefix=""M"" Path=""M1"">
  </Model>
</UCM-Document>";

        private Establish Context = () =>
            {
                _textReader = new StringReader(SavedDocument);
                _serializer = new UseCaseMakerLibrary.Services.LegacyXmlSerializer();
            };

        private Because Of = () => _model = _serializer.DeSerialize(_textReader);

        private It Should_return_valid_model = () => _model.ShouldNotBeNull();

        private static TextReader _textReader;
        private static ISerializer<Model> _serializer;
        private static Exception _exception;
        private static Model _model;
    }
}