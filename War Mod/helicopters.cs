{$CLEO .cs}

Thread "WAR"

:WAR_100
wait 500
if and
$WAR_WarStatus == 1
player.Defined($Player_Char)
jf @WAR_100
model.Load(285)
model.Load(287)
model.Load(425)
model.Load(362)
model.Load(359)
model.Load(356)
model.Load(469)
if and
model.Available(285)
model.Available(287)
model.Available(425)
model.Available(362)
model.Available(359)
model.Available(356)
model.Available(469)
jf @WAR_100
32@ = 0
33@ = 0

:WAR_200
wait 0
if
$WAR_WarStatus == 1
jf @WAR_1000
if
player.Defined($Player_Char)
jf @WAR_200
if
056E:   car 0@ defined
jf @WAR_300
if 
0205:   actor $PLAYER_ACTOR near_car 0@ radius 170.0 170.0 200.0 flag 0
jf @WAR_250
0227: 21@ = car 0@ health
if
21@ <= 10
jf @WAR_700
if and
actor.DestroyInstantly(9@)
actor.DestroyInstantly(2@)
actor.RemoveReferences(1@)
car.RemoveReferences(0@)
32@ = 0
jump @WAR_260

:WAR_250
actor.DestroyInstantly(2@)
actor.DestroyInstantly(1@)
car.Destroy(0@)
jump @WAR_260

:WAR_260
if
056D:   actor 9@ defined
jf @WAR_300
actor.DestroyInstantly(9@)

:WAR_300
0819: 3@ = actor $PLAYER_ACTOR distance_from_ground
if
3@ <= 150.0
jf @WAR_400
if
32@ >= 17000
jf @WAR_400
0208: 14@ = random_float_in_ranges -40.0 40.0
04C4: store_coords_to 6@ 7@ 8@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 10.0
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ 150.0 70.0
if
06BD:   no_obstacles_between 6@ 7@ 8@ and 3@ 4@ 5@ solid 1 car 0 actor 0 object 0 particle 0
jf @WAR_400
0208: 20@ = random_float_in_ranges -10.0 10.0
if
20@ >= 0.0
jf @WAR_350
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ 150.0 70.0
00A5: 0@ = create_car 425 at 3@ 4@ 5@
0129: 1@ = create_actor_pedtype 7 model 287 in_car 0@ driverseat
0825: set_helicopter 0@ instant_rotor_start
9@ = actor.Create(gang1, 287, 3@, 4@, 5@)
actor.GiveWeaponAndAmmo(9@, 35, 99999)
0619: enable_actor 9@ collision_detection 0
0337: set_actor 9@ visibility 0
actor.SetImmunities(9@, 1, 1, 1, 1, 1)
0946: set_actor 9@ actions_uninterupted_by_weapon_fire 0
07DD: set_actor 9@ attack_rate 100
02E2: set_actor 9@ weapon_accuracy_to 80
0464: put_actor 9@ into_turret_on_car 0@ at_car_offset 0.0 4.0 -4.3 position 0 shooting_angle_limit 180.0 with_weapon 35
099F: AS_actor 9@ ignore_weapon_range 1
05E2: AS_actor 9@ kill_actor $PLAYER_ACTOR
09B5: set_actor 9@ signal_after_kill 0
07DD: set_actor 9@ attack_rate 100
2@ = actor.Create(gang1, 285, 3@, 4@, 5@)
actor.GiveWeaponAndAmmo(2@, 31, 99999)
0619: enable_actor 2@ collision_detection 0
0337: set_actor 2@ visibility 0
actor.SetImmunities(2@, 1, 1, 1, 1, 1)
0946: set_actor 2@ actions_uninterupted_by_weapon_fire 0
07DD: set_actor 2@ attack_rate 100 
02E2: set_actor 2@ weapon_accuracy_to 90
0464: put_actor 2@ into_turret_on_car 0@ at_car_offset 0.0 5.0 -2.3 position 0 shooting_angle_limit 180.0 with_weapon 31
099F: AS_actor 2@ ignore_weapon_range 1
09B5: set_actor 2@ signal_after_kill 0
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 15.0
0208: 20@ = random_float_in_ranges -40.0 40.0
005B: 3@ += 20@ 
0208: 20@ = random_float_in_ranges -10.0 50.0
005B: 4@ += 20@ 
04A2: set_heli 0@ fly_to 3@ 4@ 5@ altitude_between 25.0 and 40.0
jump @WAR_400

:WAR_350
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ 150.0 70.0
00A5: 0@ = create_car 469 at 3@ 4@ 5@
0129: 1@ = create_actor_pedtype 7 model 287 in_car 0@ driverseat
0825: set_helicopter 0@ instant_rotor_start
2@ = actor.Create(gang1, 287, 3@, 4@, 5@)
actor.GiveWeaponAndAmmo(2@, 38, 99999)
0619: enable_actor 2@ collision_detection 0
0337: set_actor 2@ visibility 0
actor.SetImmunities(2@, 1, 1, 1, 1, 1)
0946: set_actor 2@ actions_uninterupted_by_weapon_fire 0
0464: put_actor 2@ into_turret_on_car 0@ at_car_offset 0.0 3.0 -1.3 position 0 shooting_angle_limit 180.0 with_weapon 38
099F: AS_actor 2@ ignore_weapon_range 1
05E2: AS_actor 2@ kill_actor $PLAYER_ACTOR
09B5: set_actor 2@ signal_after_kill 0
02E2: set_actor 2@ weapon_accuracy_to 75
07DD: set_actor 2@ attack_rate 100 
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 0.0
0208: 20@ = random_float_in_ranges -40.0 40.0
005B: 3@ += 20@  
0208: 20@ = random_float_in_ranges -10.0 50.0
005B: 4@ += 20@  
04A2: set_heli 0@ fly_to 3@ 4@ 5@ altitude_between 10.0 and 15.0
jump @WAR_400

:WAR_400
if
$WAR_WarStatus == 1
jf @WAR_1000
if
player.Defined($Player_Char)
jf @WAR_200
if
056E:   car 10@ defined
jf @WAR_500
if 
0205:   actor $PLAYER_ACTOR near_car 10@ radius 170.0 170.0 200.0 flag 0
jf @WAR_450
0227: 21@ = car 10@ health
if
21@ <= 10
jf @WAR_600
actor.DestroyInstantly(12@)
actor.RemoveReferences(11@)
car.RemoveReferences(10@)
marker.Disable(23@)
32@ = 0
jump @WAR_460

:WAR_450
actor.DestroyInstantly(12@)
actor.DestroyInstantly(11@)
car.Destroy(10@)
marker.Disable(23@)
jump @WAR_460

:WAR_460
if
056D:   actor 13@ defined
jf @WAR_500
actor.DestroyInstantly(13@)

:WAR_500
0819: 3@ = actor $PLAYER_ACTOR distance_from_ground
if
3@ <= 150.0
jf @WAR_200
if
33@ >= 17000
jf @WAR_200
0208: 14@ = random_float_in_ranges -40.0 40.0
04C4: store_coords_to 6@ 7@ 8@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 10.0
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ -150.0 70.0
if
06BD:   no_obstacles_between 0@ 1@ 2@ and 3@ 4@ 5@ solid 1 car 0 actor 0 object 0 particle 0
jf @WAR_200
28@ = 0
0208: 20@ = random_float_in_ranges -10.0 10.0
if
20@ >= 0.0
jf @WAR_550
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ -150.0 70.0
00A5: 10@ = create_car 425 at 3@ 4@ 5@
0129: 11@ = create_actor_pedtype 8 model 285 in_car 10@ driverseat
0825: set_helicopter 10@ instant_rotor_start
13@ = actor.Create(gang2, 285, 3@, 4@, 5@)
actor.GiveWeaponAndAmmo(13@, 35, 99999)
0619: enable_actor 13@ collision_detection 0
0337: set_actor 13@ visibility 0
actor.SetImmunities(13@, 1, 1, 1, 1, 1)
0946: set_actor 13@ actions_uninterupted_by_weapon_fire 0
07DD: set_actor 13@ attack_rate 100
02E2: set_actor 13@ weapon_accuracy_to 40
0464: put_actor 13@ into_turret_on_car 10@ at_car_offset 0.0 4.0 -4.3 position 0 shooting_angle_limit 180.0 with_weapon 35
099F: AS_actor 13@ ignore_weapon_range 1
09B5: set_actor 13@ signal_after_kill 0
12@ = actor.Create(gang2, 285, 3@, 4@, 5@)
actor.GiveWeaponAndAmmo(12@, 31, 99999)
0619: enable_actor 12@ collision_detection 0
0337: set_actor 12@ visibility 0
actor.SetImmunities(12@, 1, 1, 1, 1, 1)
0946: set_actor 12@ actions_uninterupted_by_weapon_fire 0
07DD: set_actor 12@ attack_rate 100 
02E2: set_actor 12@ weapon_accuracy_to 90
0464: put_actor 12@ into_turret_on_car 10@ at_car_offset 0.0 5.0 -2.3 position 0 shooting_angle_limit 180.0 with_weapon 31
099F: AS_actor 12@ ignore_weapon_range 1
09B5: set_actor 12@ signal_after_kill 0
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 15.0
0208: 20@ = random_float_in_ranges -40.0 40.0
005B: 3@ += 20@  
0208: 20@ = random_float_in_ranges -10.0 50.0
005B: 4@ += 20@  
04A2: set_heli 10@ fly_to 3@ 4@ 5@ altitude_between 25.0 and 40.0
jump @WAR_200

:WAR_550
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ -150.0 70.0
00A5: 10@ = create_car 469 at 3@ 4@ 5@
0129: 11@ = create_actor_pedtype 8 model 285 in_car 10@ driverseat
0825: set_helicopter 10@ instant_rotor_start
12@ = actor.Create(gang2, 285, 3@, 4@, 5@)
actor.GiveWeaponAndAmmo(12@, 38, 99999)
0619: enable_actor 12@ collision_detection 0
0337: set_actor 12@ visibility 0
actor.SetImmunities(12@, 1, 1, 1, 1, 1)
0946: set_actor 12@ actions_uninterupted_by_weapon_fire 0
07DD: set_actor 12@ attack_rate 100 
02E2: set_actor 12@ weapon_accuracy_to 75
0464: put_actor 12@ into_turret_on_car 10@ at_car_offset 0.0 3.0 -1.3 position 0 shooting_angle_limit 180.0 with_weapon 38
099F: AS_actor 12@ ignore_weapon_range 1
09B5: set_actor 12@ signal_after_kill 0
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 0.0
0208: 20@ = random_float_in_ranges -40.0 40.0
005B: 3@ += 20@ 
0208: 20@ = random_float_in_ranges -10.0 50.0
005B: 4@ += 20@  
04A2: set_heli 10@ fly_to 3@ 4@ 5@ altitude_between 10.0 and 15.0
jump @WAR_200

:WAR_600
if
02E0:   actor 12@ firing_weapon
jf @WAR_200
0669: 8@ = attach_particle "TANK_FIRE" to_actor 12@ with_offset 0.0 -0.7 1.0 type 1
064F: remove_references_to_particle 8@
jump @WAR_200

:WAR_700
if
02E0:   actor 2@ firing_weapon
jf @WAR_400
0669: 8@ = attach_particle "TANK_FIRE" to_actor 2@ with_offset 0.0 -0.7 1.0 type 1
064F: remove_references_to_particle 8@
jump @WAR_400

:WAR_1000
if
056E:   car 10@ defined
jf @WAR_1100
actor.DestroyInstantly(12@)
actor.DestroyInstantly(11@)
car.Destroy(10@)
jump @WAR_1460

:WAR_1100
if
056E:   car 0@ defined
jf @WAR_200
actor.DestroyInstantly(2@)
actor.DestroyInstantly(1@)
car.Destroy(0@)
jump @WAR_1260

:WAR_1260
if
056D:   actor 9@ defined
jf @WAR_200
actor.DestroyInstantly(9@)
jump @WAR_200

:WAR_1460
if
056D:   actor 13@ defined
jf @WAR_1100
actor.DestroyInstantly(13@)
jump @WAR_1100