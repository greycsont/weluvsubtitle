namespace weluvsubtitle.Relay;

public static class Id
{
    public static class Player
    {
        public const string prefix = "player.";

        public static class NewMovement
        {
            public const string prefix = Player.prefix + "new_movement.";
            public const string parry =  prefix + "parry";
        }

        public static class Rocket
        {
            public const string prefix = Player.prefix + "rocket.";
            public const string shoot = prefix + "shoot";
            public const string shootCannonball = prefix + "shoot_cannonball";
            public const string freezeRockets = prefix + "freeze_rockets";
            public const string unfreezeRockets = prefix + "unfreeze_rockets";
            public const string timeTicking = prefix + "time_ticking";
            public const string shootNapalm = prefix + "shoot_napalm";
            
        }

        public static class Railcannon
        {
            public const string prefix = Player.prefix + "railcannon.";
            public const string shootElectric = prefix + "shoot_electric";
            public const string shootMaliciousBeam = prefix + "shoot_malicious_beam";
            public const string shootHarpoon = prefix + "shoot_harpoon";
            public const string maxCharge = prefix + "max_charge";
        }

        public static class Nailgun
        {
            public const string prefix =  Player.prefix + "nailgun.";
            public const string shootSaw = prefix + "shoot_saw";
            public const string shootNail = prefix + "shoot_nail";
            public const string shootZapper = prefix + "shoot_zapper";
            public const string superSaw = prefix + "super_saw";
            public const string burstFire = prefix + "burst_nail";
            public const string shootMagnet = prefix + "shoot_magnet";
        }

        public static class Shotgun
        {
            public const string prefix = Player.prefix + "shotgun.";
            public const string shoot = prefix + "shoot";
            public const string shootSink = prefix + "shoot_sink";
            public const string shootSaw = prefix + "shoot_saw";
            public const string pumpLevel1 = prefix + "pump_level1";
            public const string pumpLevel2 = prefix + "pump_level2";
            public const string pumpLevel3 = prefix + "pump_level3";
        }

        public static class ShotgunHammer
        {
            public const string prefix = Player.prefix + "shotgun_hammer.";
            public const string hit= prefix + "hit";
            public const string throwNade = prefix + "throwNade";
            public const string shootSaw = prefix + "shoot_saw";
            public const string pumpLevel1 = prefix + "pump_level1";
            public const string pumpLevel2 = prefix + "pump_level2";
            public const string pumpLevel3 = prefix + "pump_level3";
        }

        public static class Revolver
        {
            public const string prefix =  Player.prefix + "revolver.";
            public const string shootBeam = prefix + "shoot_beam";
            public const string shootPiercerBeam = prefix + "shoot_piercer_beam";
            public const string shootSharpShooterBeam = prefix + "shoot_sharpshooter_beam";
            public const string throwCoin = prefix  + "throw_coin";
            
        }
    }

    public static class Enemy
    {
        
    }

    public static class Environment
    {
        public const string prefix = "environment.";
        public const string explosion = prefix + "explosion";
    }
}
