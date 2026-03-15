namespace weluvsubtitle.Relay;

public static class Id
{
    public static class Player
    {
        public static class NewMovement
        {
            public const string parry = "player.new_movement.parry";
        }

        public static class Rocket
        {
            public const string shoot            = "player.rocket.shoot";
            public const string shootCannonball  = "player.rocket.shoot_cannonball";
            public const string freezeRockets    = "player.rocket.freeze_rockets";
            public const string unfreezeRockets  = "player.rocket.unfreeze_rockets";
            public const string timeTicking      = "player.rocket.time_ticking";
            public const string shootNapalm      = "player.rocket.shoot_napalm";
        }

        public static class Railcannon
        {
            public const string shootElectric      = "player.railcannon.shoot_electric";
            public const string shootMaliciousBeam = "player.railcannon.shoot_malicious_beam";
            public const string shootHarpoon       = "player.railcannon.shoot_harpoon";
            public const string maxCharge          = "player.railcannon.max_charge";
        }

        public static class Nailgun
        {
            public const string shootSaw    = "player.nailgun.shoot_saw";
            public const string shootNail   = "player.nailgun.shoot_nail";
            public const string shootZapper = "player.nailgun.shoot_zapper";
            public const string superSaw    = "player.nailgun.super_saw";
            public const string burstFire   = "player.nailgun.burst_nail";
            public const string shootMagnet = "player.nailgun.shoot_magnet";
        }

        public static class Shotgun
        {
            public const string shoot      = "player.shotgun.shoot";
            public const string shootSink  = "player.shotgun.shoot_sink";
            public const string shootSaw   = "player.shotgun.shoot_saw";
            public const string pumpLevel1 = "player.shotgun.pump_level1";
            public const string pumpLevel2 = "player.shotgun.pump_level2";
            public const string pumpLevel3 = "player.shotgun.pump_level3";
        }

        public static class ShotgunHammer
        {
            public const string hit        = "player.shotgun_hammer.hit";
            public const string throwNade  = "player.shotgun_hammer.throw_nade";
            public const string shootSaw   = "player.shotgun_hammer.shoot_saw";
            public const string pumpLevel1 = "player.shotgun_hammer.pump_level1";
            public const string pumpLevel2 = "player.shotgun_hammer.pump_level2";
            public const string pumpLevel3 = "player.shotgun_hammer.pump_level3";
        }

        public static class Revolver
        {
            public const string shootBeam             = "player.revolver.shoot_beam";
            public const string shootPiercerBeam      = "player.revolver.shoot_piercer_beam";
            public const string shootSharpShooterBeam = "player.revolver.shoot_sharpshooter_beam";
            public const string throwCoin             = "player.revolver.throw_coin";
        }
    }

    public static class Enemy
    {
    }

    public static class Environment
    {
        public const string explosion        = "environment.explosion";
        public const string activateLandMine = "environment.activate_landmine";
    }
}