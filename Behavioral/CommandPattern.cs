using System;

namespace Behavioral
{
    // Reciever
    public class CeilingFan
    {
        public string location = "";
        public int level;
        public static int HIGH = 2;
        public static int MEDIUM = 1;
        public static int LOW = 0;
        public CeilingFan(string location)
        {
            this.location = location;
        }
        public void high()
        {
            // turns the ceiling fan on to high
            level = HIGH;
            Console.WriteLine(location + " ceiling fan is on high");
        }
        public void medium()
        {
            // turns the ceiling fan on to medium
            level = MEDIUM;
            Console.WriteLine(location + " ceiling fan is on medium");
        }
        public void low()
        {
            // turns the ceiling fan on to low
            level = LOW;
            Console.WriteLine(location + " ceiling fan is on low");
        }
        public void off()
        {
            // turns the ceiling fan off
            level = 0;
            Console.WriteLine(location + " ceiling fan is off");
        }
        public int getSpeed()
        {
            return level;
        }
    }
    public class GarageDoor
    {
        public string location;
        public GarageDoor(string location)
        {
            this.location = location;
        }
        public void up()
        {
            Console.WriteLine(location + " garage Door is Up");
        }
        public void down()
        {
            Console.WriteLine(location + " garage Door is Down");
        }
        public void stop()
        {
            Console.WriteLine(location + " garage Door is Stopped");
        }
        public void lightOn()
        {
            Console.WriteLine(location + " garage light is on");
        }
        public void lightOff()
        {
            Console.WriteLine(location + " garage light is off");
        }
    }
    public class Hottub
    {
        public Boolean on;
        public int temperature;
        public Hottub()
        {
        }
        public void On()
        {
            on = true;
        }
        public void Off()
        {
            on = false;
        }
        public void bubblesOn()
        {
            if (on)
            {
                Console.WriteLine("Hottub is bubbling!");
            }
        }
        public void bubblesOff()
        {
            if (on)
            {
                Console.WriteLine("Hottub is not bubbling");
            }
        }
        public void jetsOn()
        {
            if (on)
            {
                Console.WriteLine("Hottub jets are on");
            }
        }
        public void jetsOff()
        {
            if (on)
            {
                Console.WriteLine("Hottub jets are off");
            }
        }
        public void setTemperature(int temperature)
        {
            this.temperature = temperature;
        }
        public void heat()
        {
            temperature = 105;
            Console.WriteLine("Hottub is heating to a steaming 105 degrees");
        }
        public void cool()
        {
            temperature = 98;
            Console.WriteLine("Hottub is cooling to 98 degrees");
        }
    }
    public class Light
    {
        public string location = "";
        public Light(String location)
        {
            this.location = location;
        }
        public void on()
        {
            Console.WriteLine(location + " light is on");
        }
        public void off()
        {
            Console.WriteLine(location + " light is off");
        }
    }
    public class Stereo
    {
        public string location;
        public Stereo(String location)
        {
            this.location = location;
        }
        public void on()
        {
            Console.WriteLine(location + " stereo is on");
        }
        public void off()
        {
            Console.WriteLine(location + " stereo is off");
        }
        public void setCD()
        {
            Console.WriteLine(location + " stereo is set for CD input");
        }
        public void setDVD()
        {
            Console.WriteLine(location + " stereo is set for DVD input");
        }
        public void setRadio()
        {
            Console.WriteLine(location + " stereo is set for Radio");
        }
        public void setVolume(int volume)
        {
            // code to set the volume
            // valid range: 1-11 (after all 11 is better than 10, right?)
            Console.WriteLine(location + " stereo volume set to " + volume);
        }
    }
    public class TV
    {
        public string location;
        public int channel;
        public TV(String location)
        {
            this.location = location;
        }
        public void on()
        {
            Console.WriteLine("TV is on");
        }
        public void off()
        {
            Console.WriteLine("TV is off");
        }
        public void setInputChannel()
        {
            this.channel = 3;
            Console.WriteLine("Channel is set for VCR");
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////

    // Commands and Interface
    public interface Command
    {
        public void execute();
        public void undo();
    }
    public class NoCommand : Command
    {
        public void execute() { }
        public void undo() { }
    }


    // Command Using State
    public class CeilingFanOffCommand : Command
    {
        CeilingFan ceilingFan;
        int prevSpeed;
        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void execute()
        {
            prevSpeed = ceilingFan.getSpeed();
            ceilingFan.off();
        }
        public void undo()
        {
            ceilingFan.level = prevSpeed;
            switch (ceilingFan.level)
            {
                case 0:
                    ceilingFan.low();
                    break;
                case 1:
                    ceilingFan.medium();
                    break;
                case 2:
                    ceilingFan.high();
                    break;
                default:
                    break;
            }
        }
    }
    public class CeilingFanOnCommand : Command
    {
        CeilingFan ceilingFan;
        public CeilingFanOnCommand(CeilingFan ceilingFan)
        {
            this.ceilingFan = ceilingFan;
        }
        public void execute()
        {
            ceilingFan.high();
        }
        public void undo()
        {
            ceilingFan.off();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////

    public class GarageDoorDownCommand : Command
    {
        GarageDoor garageDoor;
        public GarageDoorDownCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }
        public void execute()
        {
            garageDoor.up();
        }
        public void undo()
        {
            garageDoor.down();
        }
    }
    public class GarageDoorUpCommand : Command
    {
        GarageDoor garageDoor;
        public GarageDoorUpCommand(GarageDoor garageDoor)
        {
            this.garageDoor = garageDoor;
        }
        public void execute()
        {
            garageDoor.up();
        }
        public void undo()
        {
            garageDoor.down();
        }
    }
    public class HottubOffCommand : Command
    {
        Hottub hottub;
        public HottubOffCommand(Hottub hottub)
        {
            this.hottub = hottub;
        }
        public void execute()
        {
            hottub.cool();
            hottub.Off();
        }
        public void undo()
        {
            hottub.On();
            hottub.heat();
            hottub.Off();
        }
    }
    public class HottubOnCommand : Command
    {
        Hottub hottub;
        public HottubOnCommand(Hottub hottub)
        {
            this.hottub = hottub;
        }
        public void execute()
        {
            hottub.On();
            hottub.heat();
            hottub.bubblesOn();
        }
        public void undo()
        {
            hottub.On();
            hottub.cool();
            hottub.Off();
        }
    }
    public class LightOffCommand : Command
    {
        Light light;
        public LightOffCommand(Light light)
        {
            this.light = light;
        }
        public void execute()
        {
            light.off();
        }
        public void undo()
        {
            light.on();
        }
    }
    public class LightOnCommand : Command
    {
        Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public void execute()
        {
            light.on();
        }
        public void undo()
        {
            light.off();
        }
    }
    public class LivingroomLightOffCommand : Command
    {
        Light light;
        public LivingroomLightOffCommand(Light light)
        {
            this.light = light;
        }
        public void execute()
        {
            light.off();
        }
        public void undo()
        {
            light.on();
        }
    }
    public class LivingroomLightOnCommand : Command
    {
        Light light;
        public LivingroomLightOnCommand(Light light)
        {
            this.light = light;
        }
        public void execute()
        {
            light.on();
        }
        public void undo()
        {
            light.off();
        }
    }
    public class StereoOffCommand : Command
    {
        Stereo stereo;
        public StereoOffCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }
        public void execute()
        {
            stereo.off();
        }
        public void undo()
        {
            stereo.on();
            stereo.setCD();
            stereo.setVolume(11);
        }
    }
    public class StereoOnWithCDCommand : Command
    {
        Stereo stereo;
        public StereoOnWithCDCommand(Stereo stereo)
        {
            this.stereo = stereo;
        }
        public void execute()
        {
            stereo.on();
            stereo.setCD();
            stereo.setVolume(11);
        }
        public void undo()
        {
            stereo.off();
        }
    }
    public class TVOnCommand : Command
    {
        TV tv;
        public TVOnCommand(TV tv)
        {
            this.tv = tv;
        }
        public void execute()
        {
            tv.on();
            tv.setInputChannel();
        }
        public void undo()
        {
            tv.off();
        }
    }
    public class TVOffCommand : Command
    {
        TV tv;
        public TVOffCommand(TV tv)
        {
            this.tv = tv;
        }
        public void execute()
        {
            tv.off();
        }
        public void undo()
        {
            tv.on();
            tv.setInputChannel();
        }

    }

    // Composite Command
    public class MacroCommand : Command
    {
        Command[] commands;
        public MacroCommand(Command[] commands)
        {
            this.commands = commands;
        }
        public void execute()
        {
            for (int i = 0; i < this.commands.Length; i++)
            {
                commands[i].execute();
            }
        }
        public void undo()
        {
            for (int i = 0; i < this.commands.Length; i++)
            {
                commands[i].undo();
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////////////////////////////////////////

    // Invoker
    public class RemoteControl
    {
        Command[] onCommands;
        Command[] offCommands;
        Command undoCommand;
        public RemoteControl()
        {
            onCommands = new Command[7];
            offCommands = new Command[7];

            Command noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
        }
        public void setCommand(int slot, Command onCommand, Command offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }
        public void onButtonWasPushed(int slot)
        {
            onCommands[slot].execute();
            undoCommand = onCommands[slot];
        }
        public void offButtonWasPushed(int slot)
        {
            offCommands[slot].execute();
            undoCommand = offCommands[slot];
        }
        public void undoButtonPushed()
        {
            undoCommand.undo();
        }
        public override string ToString()
        {

            string stringBuff = "";
            stringBuff = $"\n------ Remote Control -------\n";
            for (int i = 0; i < onCommands.Length; i++)
            {
                stringBuff += ($"[slot {i}] {onCommands[i].GetType().Name} {offCommands[i].GetType().Name} \n");
            }
            return stringBuff;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////

    // Client
    public class RemoteLoader
    {
        public static void Test()
        {
            RemoteControl remoteControl = new RemoteControl();

            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");
            CeilingFan ceilingFan = new CeilingFan("Living Room");
            GarageDoor garageDoor = new GarageDoor("Garage");
            Stereo stereo = new Stereo("Living Room");
            TV tv = new TV("Living Room");
            Hottub hottub = new Hottub();

            LightOnCommand livingRoomLightOn =
                    new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff =
                    new LightOffCommand(livingRoomLight);
            LightOnCommand kitchenLightOn =
                    new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOff =
                    new LightOffCommand(kitchenLight);

            CeilingFanOnCommand ceilingFanOn =
                    new CeilingFanOnCommand(ceilingFan);
            CeilingFanOffCommand ceilingFanOff =
                    new CeilingFanOffCommand(ceilingFan);

            GarageDoorUpCommand garageDoorUp =
                    new GarageDoorUpCommand(garageDoor);
            GarageDoorDownCommand garageDoorDown =
                    new GarageDoorDownCommand(garageDoor);

            StereoOnWithCDCommand stereoOnWithCD =
                    new StereoOnWithCDCommand(stereo);
            StereoOffCommand stereoOff =
                    new StereoOffCommand(stereo);

            TVOnCommand tvOn =
                    new TVOnCommand(tv);
            TVOffCommand tvOff =
                    new TVOffCommand(tv);

            HottubOnCommand hottubOn =
                    new HottubOnCommand(hottub);
            HottubOffCommand hottubOff =
                    new HottubOffCommand(hottub);



            Command[] partyOn = { livingRoomLightOn, stereoOnWithCD, tvOn, hottubOn };
            Command[] partyOff = { livingRoomLightOff, stereoOff, tvOff, hottubOff };
            MacroCommand partyOnCommand =
                    new MacroCommand(partyOn);
            MacroCommand partyOffCommand =
                    new MacroCommand(partyOff);

            remoteControl.setCommand(0, livingRoomLightOn, livingRoomLightOff);
            remoteControl.setCommand(1, kitchenLightOn, kitchenLightOff);
            remoteControl.setCommand(2, ceilingFanOn, ceilingFanOff);
            remoteControl.setCommand(3, stereoOnWithCD, stereoOff);
            remoteControl.setCommand(4, partyOnCommand, partyOffCommand);

            Console.WriteLine(remoteControl);

            remoteControl.onButtonWasPushed(0);
            remoteControl.offButtonWasPushed(0);
            remoteControl.onButtonWasPushed(1);
            remoteControl.offButtonWasPushed(1);
            remoteControl.onButtonWasPushed(2);
            remoteControl.offButtonWasPushed(2);
            remoteControl.onButtonWasPushed(3);
            remoteControl.offButtonWasPushed(3);

            Console.WriteLine("-------------------------------------------------------------- Party Mode On -----------------------------------------------");
            remoteControl.onButtonWasPushed(4);
            remoteControl.offButtonWasPushed(4);
            remoteControl.undoButtonPushed();
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////

}