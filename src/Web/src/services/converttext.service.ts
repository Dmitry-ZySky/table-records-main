export class ConvertTextService {
    public async csvToJson(csvText: string){

        var lines = csvText.split("\r\n");

        var result: Array<any> = [];

        var headers = lines[0].split(",");

        for (var i = 1; i < lines.length - 1; i++) {
            let obj: any = new Object();
            var currentValue = lines[i].split(",");

            for (var j = 0; j < headers.length; j++) {
                switch (headers[j]) {
                    case "RequiredCol":
                    case "requiredStringCol":
                        headers[j] = "requiredStringCol";
                        break;
                    case "StringCol":
                    case "stringCol":
                        headers[j] = "stringCol";
                        break;
                    case "Date":
                    case "dateCol":
                        headers[j] = "dateCol";
                        currentValue[j] = new Date(currentValue[j]).toJSON();
                        break;
                    case "Select":
                    case "selectCol":
                        headers[j] = "selectCol";
                        break;
                    default:
                        let errorObj: any = new Object();
                        errorObj["Error"] = "Upload failed for reason: Bad header - '" + headers[j].toString() + "'";
                        return errorObj;
                }

                obj[headers[j]] = currentValue[j];
            }
            result.push(obj);
        }


        return result; //return as JSON object
    }
}
