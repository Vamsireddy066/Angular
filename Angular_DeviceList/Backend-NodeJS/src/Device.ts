enum Status{
    ONLINE = 'ONLINE',
    OFFLINE= 'OFFLINE'
}

export class Device {
    static readonly Status = Status;
    public id : string;
    public name : string;
    public description : string;
    public status : Status;

    constructor(init?: Partial<Device>){
        Object.assign(this, init)
    }
}