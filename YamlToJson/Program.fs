namespace YamlToJson

open System
open Microsoft.FSharp.Core

module YamlToJson =

    let convert (input: string) =
        let yaml = YamlDotNet.Serialization.Deserializer().Deserialize(input)
        let json = Newtonsoft.Json.JsonConvert.SerializeObject(yaml, Newtonsoft.Json.Formatting.Indented)
        json

module Program =

    [<EntryPoint>]
    let mainAsync argv =

        if Console.IsInputRedirected then
            let input = Console.In.ReadToEnd()
            let json = YamlToJson.convert input
            Console.Write(json)
            0
        else
            Console.Error.WriteLine("No input")
            1
