using System;

namespace Structural
{
    // Compoenents

    public class CdPlayer
    {
        public string description;
        public int currentTrack;
        public Amplifier amplifier;
        public string title;
        public CdPlayer(string description, Amplifier amplifier)
        {
            this.description = description;
            this.amplifier = amplifier;
        }
        public void on()
        {
            Console.WriteLine(description + " on");
        }
        public void off()
        {
            Console.WriteLine(description + " off");
        }
        public void eject()
        {
            title = null;
            Console.WriteLine(description + " eject");
        }
        public void play(string title)
        {
            this.title = title;
            currentTrack = 0;
            Console.WriteLine(description + " playing \"" + title + "\"");
        }
        public void play(int track)
        {
            if (title == null)
            {
                Console.WriteLine(description + " can't play track " + currentTrack +
                        ", no cd inserted");
            }
            else
            {
                currentTrack = track;
                Console.WriteLine(description + " playing track " + currentTrack);
            }
        }
        public void stop()
        {
            currentTrack = 0;
            Console.WriteLine(description + " stopped");
        }
        public void pause()
        {
            Console.WriteLine(description + " paused \"" + title + "\"");
        }
        public override string ToString()
        {
            return description;
        }
    }
    public class PopcornPopper
    {
        public string description;
        public PopcornPopper(string description)
        {
            this.description = description;
        }
        public void on()
        {
            Console.WriteLine(description + " on");
        }
        public void off()
        {
            Console.WriteLine(description + " off");
        }
        public void pop()
        {
            Console.WriteLine(description + " popping popcorn!");
        }
        public override string ToString()
        {
            return description;
        }
    }
    public class Projector
    {
        public string description;
        public StreamingPlayer player;
        public Projector(string description, StreamingPlayer player)
        {
            this.description = description;
            this.player = player;
        }
        public void on()
        {
            Console.WriteLine(description + " on");
        }
        public void off()
        {
            Console.WriteLine(description + " off");
        }
        public void wideScreenMode()
        {
            Console.WriteLine(description + " in widescreen mode (16x9 aspect ratio)");
        }
        public void tvMode()
        {
            Console.WriteLine(description + " in tv mode (4x3 aspect ratio)");
        }
        public override string ToString()
        {
            return description;
        }
    }
    public class Screen
    {
        public string description;
        public Screen(string description)
        {
            this.description = description;
        }
        public void up()
        {
            Console.WriteLine(description + " going up");
        }
        public void down()
        {
            Console.WriteLine(description + " going down");
        }
        public override string ToString()
        {
            return description;
        }
    }
    public class StreamingPlayer
    {
        public string description;
        public int currentChapter;
        public Amplifier amplifier;
        public string movie;
        public StreamingPlayer(string description, Amplifier amplifier)
        {
            this.description = description;
            this.amplifier = amplifier;
        }
        public void on()
        {
            Console.WriteLine(description + " on");
        }
        public void off()
        {
            Console.WriteLine(description + " off");
        }
        public void play(string movie)
        {
            this.movie = movie;
            currentChapter = 0;
            Console.WriteLine(description + " playing \"" + movie + "\"");
        }
        public void play(int chapter)
        {
            if (movie == null)
            {
                Console.WriteLine(description + " can't play chapter " + chapter + " no movie selected");
            }
            else
            {
                currentChapter = chapter;
                Console.WriteLine(description + " playing chapter " + currentChapter + " of \"" + movie + "\"");
            }
        }
        public void stop()
        {
            currentChapter = 0;
            Console.WriteLine(description + " stopped \"" + movie + "\"");
        }
        public void pause()
        {
            Console.WriteLine(description + " paused \"" + movie + "\"");
        }
        public void setTwoChannelAudio()
        {
            Console.WriteLine(description + " set two channel audio");
        }
        public void setSurroundAudio()
        {
            Console.WriteLine(description + " set surround audio");
        }
        public override string ToString()
        {
            return description;
        }
    }
    public class TheaterLights
    {
        public string description;
        public TheaterLights(string description)
        {
            this.description = description;
        }
        public void on()
        {
            Console.WriteLine(description + " on");
        }
        public void off()
        {
            Console.WriteLine(description + " off");
        }
        public void dim(int level)
        {
            Console.WriteLine(description + " dimming to " + level + "%");
        }
        public override string ToString()
        {
            return description;
        }
    }
    public class Tuner
    {
        public string description;
        public Amplifier amplifier;
        public double frequency;
        public Tuner(string description, Amplifier amplifier)
        {
            this.description = description;
        }
        public void on()
        {
            Console.WriteLine(description + " on");
        }
        public void off()
        {
            Console.WriteLine(description + " off");
        }
        public void setFrequency(double frequency)
        {
            Console.WriteLine(description + " setting frequency to " + frequency);
            this.frequency = frequency;
        }
        public void setAm()
        {
            Console.WriteLine(description + " setting AM mode");
        }
        public void setFm()
        {
            Console.WriteLine(description + " setting FM mode");
        }
        public override string ToString()
        {
            return description;
        }
    }
    public class Amplifier
    {
        public string description;
        public Tuner tuner;
        public StreamingPlayer player;
        public Amplifier(string description)
        {
            this.description = description;
        }
        public void on()
        {
            Console.WriteLine(description + " on");
        }
        public void off()
        {
            Console.WriteLine(description + " off");
        }
        public void setStereoSound()
        {
            Console.WriteLine(description + " stereo mode on");
        }
        public void setSurroundSound()
        {
            Console.WriteLine(description + " surround sound on (5 speakers, 1 subwoofer)");
        }
        public void setVolume(int level)
        {
            Console.WriteLine(description + " setting volume to " + level);
        }
        public void setTuner(Tuner tuner)
        {
            Console.WriteLine(description + " setting tuner to " + player);
            this.tuner = tuner;
        }
        public void setStreamingPlayer(StreamingPlayer player)
        {
            Console.WriteLine(description + " setting Streaming player to " + player);
            this.player = player;
        }
        public override string ToString()
        {
            return description;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////

    // Facade Class
    public class HomeTheaterFacade
    {
        public Amplifier amp;
        public Tuner tuner;
        public StreamingPlayer player;
        public CdPlayer cd;
        public Projector projector;
        public TheaterLights lights;
        public Screen screen;
        public PopcornPopper popper;
        public HomeTheaterFacade(Amplifier amp,
                     Tuner tuner,
                     StreamingPlayer player,
                     Projector projector,
                     Screen screen,
                     TheaterLights lights,
                     PopcornPopper popper)
        {

            this.amp = amp;
            this.tuner = tuner;
            this.player = player;
            this.projector = projector;
            this.screen = screen;
            this.lights = lights;
            this.popper = popper;
        }
        public void watchMovie(string movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            popper.on();
            popper.pop();
            lights.dim(10);
            screen.down();
            projector.on();
            projector.wideScreenMode();
            amp.on();
            amp.setStreamingPlayer(player);
            amp.setSurroundSound();
            amp.setVolume(5);
            player.on();
            player.play(movie);
        }


        public void endMovie()
        {
            Console.WriteLine("Shutting movie theater down...");
            popper.off();
            lights.on();
            screen.up();
            projector.off();
            amp.off();
            player.stop();
            player.off();
        }

        public void listenToRadio(double frequency)
        {
            Console.WriteLine("Tuning in the airwaves...");
            tuner.on();
            tuner.setFrequency(frequency);
            amp.on();
            amp.setVolume(5);
            amp.setTuner(tuner);
        }

        public void endRadio()
        {
            Console.WriteLine("Shutting down the tuner...");
            tuner.off();
            amp.off();
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////


    // Client
    public class HomeTheaterTestDrive
    {
        public static void Test()
        {
            Amplifier amp = new Amplifier("Amplifier");
            Tuner tuner = new Tuner("AM/FM Tuner", amp);
            StreamingPlayer player = new StreamingPlayer("Streaming Player", amp);
            CdPlayer cd = new CdPlayer("CD Player", amp);
            Projector projector = new Projector("Projector", player);
            TheaterLights lights = new TheaterLights("Theater Ceiling Lights");
            Screen screen = new Screen("Theater Screen");
            PopcornPopper popper = new PopcornPopper("Popcorn Popper");

            HomeTheaterFacade homeTheater =
                    new HomeTheaterFacade(amp, tuner, player,
                            projector, screen, lights, popper);

            homeTheater.watchMovie("Raiders of the Lost Ark");
            homeTheater.endMovie();
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////
}