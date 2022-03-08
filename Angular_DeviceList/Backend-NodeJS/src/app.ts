import express  from "express";
import { Device } from "./Device";

const app = express();
const port = 3000;
const devices = [
    {
        id : "GHVC66",
        name : "Google Home Voice Contoller",
        description : "It provides voice enabled services like alarms, lights, thermostats and lot more.",
        status : Device.Status.ONLINE,
    },
    {
        id : "AEPVC67",
        name : "Amazon Echo Plus Voice Contoller",
        description : "It provides voice enabled services like answering phone calls, checking weather and lot more.",
        status : Device.Status.OFFLINE,
    },
    {
        id : "ASL68",
        name : "Angust Smart Lock",
        description : "It helps keep thieves away and provides an extra layer of security for your home.",
        status : Device.Status.OFFLINE,
    },
    {
        id : "FB69",
        name : "Foobot",
        description : "It helps to improve the air quality in houses, cafes, workplaces, and other indoor public spaces.",
        status : Device.Status.ONLINE,
    }
]

app.get('/devices', (req,res)=>{
    if (devices.length > 0)
    {
        const devicelist = devices.map((e) => {
            return {id: e.id,
            name: e.name,
            status: e.status}
        })
        res.send(devicelist);
    }
    else
    {
        res.send({error: "No device"});
    }
})

app.get('/devices/:id', (req,res) => {
    const id = req.params.id;
    if (id != null)
    {
        const selectedDevice = devices.filter(e => e.id == id);
        if (selectedDevice && selectedDevice.length > 0)
        {
            res.send(selectedDevice[0]);
        }
        else
        {
            res.send({error: "Device Not Found"});
        }
    }
    else
    {
        res.send({error: "Please provide device id"});
    }
})

const server = app.listen(port, () =>{
    return console.log('server is running on 3000')
});

server.on('error', e=> console.error("Error", e));
