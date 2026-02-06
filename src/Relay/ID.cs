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
            public const string shootEject = prefix + "shoot_eject";
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
