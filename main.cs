{$CLEO .cs}
{$USE ini}

// MADE BY ENGINESTEIN

thread "WAR"
0AF0: 0@ = read_int_from_ini_file "cleo\settings.ini" section "Settings" key "EnableWar"
008A: $WAR_WarStatus = 0@ // (int)

:WAR_50
wait 500
if
$WAR_WarStatus == 1
jf @WAR_50
if
player.Defined($Player_Char)
jf @WAR_50
model.Load(#M4)
model.Load(#AK47)
model.Load(#ARMY)
model.Load(#SWAT)
038B: load_requested_models
if and
model.Available(#M4)
Model.Available(#AK47)
model.Available(#ARMY)
model.Available(#SWAT)
jf @WAR_50
06D0: enable_emergency_traffic 0
06D7: enable_train_traffic 0
0923: enable_air_traffic 0
01EB: set_traffic_density_multiplier_to 0.0
03DE: set_pedestrians_density_multiplier_to 0.0
01F0: set_max_wanted_level_to 0
06C8: enable_riot 1
0879: enable_gang_wars 0
30@ = 0
31@ = 0

:WAR_400 
wait 0
if
$WAR_WarStatus == 1
jf @WAR_1000
if
player.Defined($Player_Char)
jf @WAR_400
if
056D:   actor 1@(30@,10i) defined
jf @WAR_500
if
0104:   actor $PLAYER_ACTOR near_actor 1@(30@,10i) radius 110.0 110.0 120.0 sphere 0
jf @WAR_450
if
actor.Dead(1@(30@,10i))
jf @WAR_800
actor.RemoveReferences(1@(30@,10i))
jump @WAR_500

:WAR_450
actor.DestroyInstantly(1@(30@,10i))
jump @WAR_500

:WAR_500  
if
30@ <= 9
jf @WAR_800
0819: 0@ = actor $PLAYER_ACTOR distance_from_ground
if
0@ <= 120.0
jf @WAR_800
0208: 0@ = random_float_in_ranges -60.0 60.0
0208: 21@ = random_float_in_ranges 75.0 100.0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 0@ 21@ 0.0
04D3: get_nearest_car_path_coords_from 21@ 22@ 23@ type 2 store_to 21@ 22@ 23@
0208: 0@ = random_float_in_ranges -7.0 7.0
005B: 21@ += 0@  // (float)
0208: 0@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 0@  // (float)
23@ += 5.0
02CE: 23@ = ground_z_at 21@ 22@ 23@
if and
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 40.0 40.0
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 110.0 110.0
jf @WAR_800
1@(30@,10i) = actor.Create(Gang1, #ARMY, 21@, 22@, 23@)
actor.GiveWeaponAndAmmo(1@(30@,10i), 30, 9999)
0223: set_actor 1@(30@,10i) health_to 150
09B5: set_actor 1@(30@,10i) signal_after_kill 0
02E2: set_actor 1@(30@,10i) weapon_accuracy_to 75
0446: set_actor 1@(30@,10i) immune_to_headshots 0
0946: set_actor 1@(30@,10i) actions_uninterupted_by_weapon_fire 0
07DD: set_actor 1@(30@,10i) attack_rate 50
087E: set_actor 1@(30@,10i) weapon_droppable 0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 0.0
0208: 0@ = random_float_in_ranges -7.0 7.0
005B: 21@ += 0@  // (float)
0208: 0@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 0@  // (float)
23@ += 5.0
02CE: 23@ = ground_z_at 21@ 22@ 23@
05D3: AS_actor 1@(30@,10i) goto_point 21@ 22@ 23@ mode 6 time -1 ms // versionA
jump @WAR_800

:WAR_600   
if
31@ <= 9
jf @WAR_900
0819: 0@ = actor $PLAYER_ACTOR distance_from_ground
if
0@ <= 120.0
jf @WAR_900
0208: 0@ = random_float_in_ranges -60.0 60.0
0208: 21@ = random_float_in_ranges -45.0 -75.0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 0@ 21@ 0.0
04D3: get_nearest_car_path_coords_from 21@ 22@ 23@ type 2 store_to 21@ 22@ 23@
0208: 0@ = random_float_in_ranges -7.0 7.0
005B: 21@ += 0@  // (float)
0208: 0@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 0@  // (float)
23@ += 5.0
02CE: 23@ = ground_z_at 21@ 22@ 23@
if and
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 40.0 40.0
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 100.0 100.0
jf @WAR_900
11@(31@,10i) = actor.Create(Gang2, #SWAT, 21@, 22@, 23@)
actor.GiveWeaponAndAmmo(11@(31@,10i), 31, 9999)
0223: set_actor 11@(31@,10i) health_to 150
09B5: set_actor 11@(31@,10i) signal_after_kill 0
02E2: set_actor 11@(31@,10i) weapon_accuracy_to 75
0446: set_actor 11@(31@,10i) immune_to_headshots 0
0946: set_actor 11@(31@,10i) actions_uninterupted_by_weapon_fire 0
07DD: set_actor 11@(31@,10i) attack_rate 50
087E: set_actor 11@(31@,10i) weapon_droppable 0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 0.0
0208: 0@ = random_float_in_ranges -7.0 7.0
005B: 21@ += 0@  // (float)
0208: 0@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 0@  // (float)
23@ += 5.0
02CE: 23@ = ground_z_at 21@ 22@ 23@
05D3: AS_actor 11@(31@,10i) goto_point 21@ 22@ 23@ mode 6 time -1 ms // versionA
jump @WAR_900

:WAR_700  
if
$WAR_WarStatus == 1
jf @WAR_1000
if
player.Defined($PLAYER_CHAR)
jf @WAR_400
if
056D:   actor 11@(31@,10i) defined
jf @WAR_600
if
0104:   actor $PLAYER_ACTOR near_actor 11@(31@,10i) radius 100.0 100.0 120.0 sphere 0
jf @WAR_750
if
actor.Dead(11@(31@,10i))
jf @WAR_900
actor.RemoveReferences(11@(31@,10i))
jump @WAR_600

:WAR_750
actor.DestroyInstantly(11@(31@,10i))
jump @WAR_600

:WAR_800
30@ += 1
if
30@ >= 10
jf @WAR_700
30@ = 0
jump @WAR_700

:WAR_900
31@ += 1
if
31@ >= 10
jf @WAR_400
31@ = 0
jump @WAR_400 

:WAR_1000
31@ = 0
30@ = 0

:WAR_1050
if
056D:   actor 11@(31@,10i) defined
jf @WAR_1100
actor.DestroyInstantly(11@(31@,10i))

:WAR_1100
31@ += 1
if
31@ >= 10
jf @WAR_1050
31@ = 0

:WAR_1200
if
056D:   actor 1@(30@,10i) defined
jf @WAR_1300
actor.DestroyInstantly(1@(30@,10i))

:WAR_1300
30@ += 1
if
30@ >= 10
jf @WAR_1200
30@ = 0
06D0: enable_emergency_traffic 1
06D7: enable_train_traffic 1
0923: enable_air_traffic 1
01EB: set_traffic_density_multiplier_to 1.0
03DE: set_pedestrians_density_multiplier_to 1.0
01F0: set_max_wanted_level_to 1
06C8: enable_riot 0
0879: enable_gang_wars 1
jump @WAR_50






















