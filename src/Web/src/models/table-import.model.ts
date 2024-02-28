//TODO fix decorators, they don't work
import { JsonObject, JsonProperty } from "json2typescript";

@JsonObject("TableImport")
export class TableImport {
    @JsonProperty("Id")
    public id: number;

    @JsonProperty("RequiredCol")
    public requiredStringCol: string;

    @JsonProperty("StringCol")
    public stringCol: string;

    @JsonProperty("DateCol")
    public dateCol: Date;

    @JsonProperty("SelectCol")
    public selectCol: string;

    constructor(id: number, requiredStringCol: string, stringCol: string, dateCol: Date, selectCol: string) {
        this.id = id;
        this.requiredStringCol = requiredStringCol;
        this.stringCol = stringCol;
        this.dateCol = dateCol;
        this.selectCol = selectCol;
    }
}
