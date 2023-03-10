{$CLEO .cs}
{$USE ini}

Thread "WAR"

:WAR_100
wait 500
if and
$WAR_WarStatus == 1
player.Defined($Player_Char)
jf @WAR_100
model.Load(470)
model.Load(2985)
model.Load(287)
model.Load(285)  
model.Load(356)    
model.Load(355)  
04ED: load_animation  "Camera"
038B: load_requested_models
if and
model.Available(470)                       
model.Available(2985)                           
model.Available(287)                          
model.Available(285)                       
model.Available(356)                           
model.Available(355) 
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
056D:   actor 2@ defined
jf @WAR_300
if 
0205:   actor $PLAYER_ACTOR near_car 0@ radius 150.0 150.0 120.0 flag 0
jf @WAR_250
0227: 31@ = car 0@ health
if or
04E7:   object 3@ in_water
31@ <= 10
jf @WAR_400
0465: remove_actor 4@ from_turret_mode
0465: remove_actor 2@ from_turret_mode
wait 10
object.Destroy(3@)
actor.RemoveReferences(4@)
actor.RemoveReferences(2@)
actor.RemoveReferences(1@)
wait 10
actor.DestroyInstantly(4@)
actor.DestroyInstantly(2@)
actor.DestroyInstantly(1@)
car.RemoveReferences(0@)
0@ = 0
jump @WAR_300

:WAR_250
0465: remove_actor 4@ from_turret_mode
0465: remove_actor 2@ from_turret_mode
wait 10
object.Destroy(3@)
actor.RemoveReferences(4@)
actor.RemoveReferences(2@)
actor.RemoveReferences(1@)
wait 10
actor.DestroyInstantly(4@)
actor.DestroyInstantly(2@)
actor.DestroyInstantly(1@)
car.Destroy(0@)
0@ = 0
jump @WAR_300

:WAR_300
0819: 31@ = actor $PLAYER_ACTOR distance_from_ground
if
31@ <= 120.0
jf @WAR_400
0208: 21@ = random_float_in_ranges -140.0 140.0
0208: 22@ = random_float_in_ranges -70.0 140.0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 21@ 22@ 0.0
04D3: get_nearest_car_path_coords_from 21@ 22@ 23@ type 2 store_to 21@ 22@ 23@
0208: 31@ = random_float_in_ranges -7.0 7.0
005B: 21@ += 31@  
0208: 31@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 31@  
23@ += 1.0
02CE: 23@ = ground_z_at 21@ 22@ 23@
if and
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 70.0 70.0
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 150.0 150.0
jf @WAR_400
00A5: 0@ = create_car 470 at 21@ 22@ 23@
actor.Create(2@, Gang1, 287, 0.0, 0.0, 0.0)
actor.GiveWeaponAndAmmo(2@, 30, 9999)
actor.Create(4@, Gang1, 287, 0.0, 0.0, 0.0)
object.Create(3@, 2985, 0.0, 0.0, 0.0)
object.CollisionDetection(3@, False)
actor.SetImmunities(2@, 1, 1, 1, 1, 1)
actor.SetImmunities(4@, 1, 1, 1, 1, 1)
0619: enable_actor 2@ collision_detection 0
0619: enable_actor 4@ collision_detection 0
099F: AS_actor 2@ ignore_weapon_range 1
0946: set_actor 2@ actions_uninterupted_by_weapon_fire 0
0946: set_actor 4@ actions_uninterupted_by_weapon_fire 1
07DD: set_actor 2@ attack_rate 100
04D7: set_actor 2@ locked 1
02E2: set_actor 2@ weapon_accuracy_to 85
09B5: set_actor 2@ signal_after_kill 0
0AF2: 21@ = read_float_from_ini_file "cleo\settings.ini" section "TurretPosition" key "X"
0AF2: 22@ = read_float_from_ini_file "cleo\settings.ini" section "TurretPosition" key "Y"
0AF2: 23@ = read_float_from_ini_file "cleo\settings.ini" section "TurretPosition" key "Z"
0AF2: 24@ = read_float_from_ini_file "cleo\settings.ini" section "Shooting" key "MaxAngle"
0464: put_actor 2@ into_turret_on_car 0@ at_car_offset 21@ 22@ 23@ position 0 shooting_angle_limit 24@ with_weapon 30
069B: attach_object 3@ to_actor 2@ with_offset 0.0 0.3 -0.56 rotation 0.0 0.0 90.0
04F4: put_actor 4@ into_turret_on_object 3@ offset_from_object_origin -0.3 0.0 0.7 orientation 3 both_side_angle_limit 0.0 lock_weapon 0
0812: AS_actor 4@ perform_animation "camstnd_idleloop" IFP "Camera" framedelta 4.0 loopA 1 lockX 0 lockY 0 lockF 0 time -1 // versionB
0208: 21@ = random_float_in_ranges -15.0 15.0
0208: 22@ = random_float_in_ranges -15.0 15.0
0129: 1@ = create_actor_pedtype 7 model 287 in_car 0@ driverseat
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 21@ 22@ 0.0
0704: car 0@ drive_to 21@ 22@ 23@
04BA: set_car 0@ speed_to 10.0
car.SetToPsychoDriver(0@)
car.Health(0@) = 5000
0337: set_actor 2@ visibility 0
jump @WAR_400

:WAR_400
if
$WAR_WarStatus == 1
jf @WAR_1000
if
player.Defined($Player_Char)
jf @WAR_200
if
056D:   actor 12@ defined
jf @WAR_500
if 
0205:   actor $PLAYER_ACTOR near_car 10@ radius 150.0 150.0 120.0 flag 0
jf @WAR_450
0227: 21@ = car 10@ health
if or
04E7:   object 13@ in_water
21@ <= 10
jf @WAR_510
0465: remove_actor 14@ from_turret_mode
0465: remove_actor 12@ from_turret_mode
wait 10
object.Destroy(13@)
actor.RemoveReferences(14@)
actor.RemoveReferences(12@)
actor.RemoveReferences(11@)
wait 10
actor.DestroyInstantly(14@)
actor.DestroyInstantly(12@)
actor.DestroyInstantly(11@)
car.RemoveReferences(10@)
jump @WAR_500

:WAR_450
0465: remove_actor 14@ from_turret_mode
0465: remove_actor 12@ from_turret_mode
wait 10
object.Destroy(13@)
actor.RemoveReferences(14@)
actor.RemoveReferences(12@)
actor.RemoveReferences(11@)
wait 10
actor.DestroyInstantly(14@)
actor.DestroyInstantly(12@)
actor.DestroyInstantly(11@)
car.Destroy(10@)
jump @WAR_500

:WAR_500
0819: 31@ = actor $PLAYER_ACTOR distance_from_ground
if
31@ <= 120.0
jf @WAR_510
0208: 21@ = random_float_in_ranges -140.0 140.0
0208: 22@ = random_float_in_ranges -130.0 70.0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 21@ 22@ 0.0
04D3: get_nearest_car_path_coords_from 21@ 22@ 23@ type 2 store_to 21@ 22@ 23@
0208: 31@ = random_float_in_ranges -7.0 7.0
005B: 21@ += 31@  
0208: 31@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 31@  
23@ += 1.0
02CE: 23@ = ground_z_at 21@ 22@ 23@
if and
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 70.0 70.0
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 150.0 150.0
jf @WAR_510
00A5: 10@ = create_car 470 at 21@ 22@ 23@
actor.Create(12@, Gang2, 285, 0.0, 0.0, 0.0)
actor.GiveWeaponAndAmmo(12@, 30, 9999)
actor.Create(14@, Gang2, 285, 0.0, 0.0, 0.0)
object.Create(13@, 2985, 0.0, 0.0, 0.0)
object.CollisionDetection(13@, False)
actor.SetImmunities(12@, 1, 1, 1, 1, 1)
actor.SetImmunities(14@, 1, 1, 1, 1, 1)
0619: enable_actor 12@ collision_detection 0
0619: enable_actor 14@ collision_detection 0
099F: AS_actor 12@ ignore_weapon_range 1
0946: set_actor 12@ actions_uninterupted_by_weapon_fire 0
0946: set_actor 14@ actions_uninterupted_by_weapon_fire 1
07DD: set_actor 12@ attack_rate 100
02E2: set_actor 12@ weapon_accuracy_to 85
04D7: set_actor 12@ locked 1
09B5: set_actor 12@ signal_after_kill 0
0AF2: 21@ = read_float_from_ini_file "cleo\settings.ini" section "TurretPosition" key "X"
0AF2: 22@ = read_float_from_ini_file "cleo\settings.ini" section "TurretPosition" key "Y"
0AF2: 23@ = read_float_from_ini_file "cleo\settings.ini" section "TurretPosition" key "Z"
0AF2: 24@ = read_float_from_ini_file "cleo\settings.ini" section "Shooting" key "MaxAngle"
0464: put_actor 12@ into_turret_on_car 10@ at_car_offset 21@ 22@ 23@ position 0 shooting_angle_limit 24@ with_weapon 30
069B: attach_object 13@ to_actor 12@ with_offset 0.0 0.3 -0.56 rotation 0.0 0.0 90.0
04F4: put_actor 14@ into_turret_on_object 13@ offset_from_object_origin -0.3 0.0 0.7 orientation 3 both_side_angle_limit 0.0 lock_weapon 0
0812: AS_actor 14@ perform_animation "camstnd_idleloop" IFP "Camera" framedelta 4.0 loopA 1 lockX 0 lockY 0 lockF 0 time -1
0208: 21@ = random_float_in_ranges -15.0 15.0
0208: 22@ = random_float_in_ranges -15.0 15.0
0129: 11@ = create_actor_pedtype 8 model 285 in_car 10@ driverseat
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 21@ 22@ 0.0
0704: car 10@ drive_to 21@ 22@ 23@
04BA: set_car 10@ speed_to 10.0
car.SetToPsychoDriver(10@)
car.Health(10@) = 5000
0337: set_actor 12@ visibility 0
jump @WAR_510

:WAR_510
if
$WAR_WarStatus == 1
jf @WAR_1000
if
player.Defined($Player_Char)
jf @WAR_200
if
056D:   actor 8@ defined
jf @WAR_550
if 
0205:   actor $PLAYER_ACTOR near_car 5@ radius 150.0 150.0 120.0 flag 0
jf @WAR_515
0227: 21@ = car 5@ health
if or
04E7:   object 6@ in_water
21@ <= 10
jf @WAR_600
0465: remove_actor 9@ from_turret_mode
0465: remove_actor 8@ from_turret_mode
wait 10
object.Destroy(6@)
actor.RemoveReferences(9@)
actor.RemoveReferences(8@)
actor.RemoveReferences(7@)
wait 10
actor.DestroyInstantly(9@)
actor.DestroyInstantly(8@)
actor.DestroyInstantly(7@)
car.RemoveReferences(5@)
jump @WAR_550

:WAR_515
0465: remove_actor 9@ from_turret_mode
0465: remove_actor 8@ from_turret_mode
wait 10
object.Destroy(6@)
actor.RemoveReferences(9@)
actor.RemoveReferences(8@)
actor.RemoveReferences(7@)
wait 10
actor.DestroyInstantly(9@)
actor.DestroyInstantly(8@)
actor.DestroyInstantly(7@)
car.Destroy(5@)

:WAR_550
0819: 31@ = actor $PLAYER_ACTOR distance_from_ground
if
31@ <= 120.0
jf @WAR_600
0208: 21@ = random_float_in_ranges -140.0 140.0
0208: 22@ = random_float_in_ranges -70.0 140.0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 21@ 22@ 0.0
04D3: get_nearest_car_path_coords_from 21@ 22@ 23@ type 2 store_to 21@ 22@ 23@
0208: 31@ = random_float_in_ranges -7.0 7.0
005B: 21@ += 31@ 
0208: 31@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 31@ 
23@ += 1.0
02CE: 23@ = ground_z_at 21@ 22@ 23@
if and
80EC:   not actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 70.0 70.0
00EC:   actor $PLAYER_ACTOR sphere 0 near_point 21@ 22@ radius 150.0 150.0
jf @WAR_600
00A5: 5@ = create_car 470 at 21@ 22@ 23@
actor.Create(8@, Gang1, 287, 0.0, 0.0, 0.0)
actor.GiveWeaponAndAmmo(8@, 30, 9999)
actor.Create(9@, Gang1, 287, 0.0, 0.0, 0.0)
object.Create(6@, 2985, 0.0, 0.0, 0.0)
object.CollisionDetection(6@, False)
actor.SetImmunities(8@, 1, 1, 1, 1, 1)
actor.SetImmunities(9@, 1, 1, 1, 1, 1)
0619: enable_actor 8@ collision_detection 0
0619: enable_actor 9@ collision_detection 0
099F: AS_actor 8@ ignore_weapon_range 1
0946: set_actor 8@ actions_uninterupted_by_weapon_fire 0
0946: set_actor 9@ actions_uninterupted_by_weapon_fire 1
07DD: set_actor 8@ attack_rate 100
02E2: set_actor 8@ weapon_accuracy_to 85
04D7: set_actor 8@ locked 1
09B5: set_actor 8@ signal_after_kill 0
0AF2: 21@ = read_float_from_ini_file "cleo\settings.ini" section "TurretPosition" key "X"
0AF2: 22@ = read_float_from_ini_file "cleo\settings.ini" section "TurretPosition" key "Y"
0AF2: 23@ = read_float_from_ini_file "cleo\settings.ini" section "TurretPosition" key "Z"
0AF2: 24@ = read_float_from_ini_file "cleo\settings.ini" section "Shooting" key "MaxAngle"
0464: put_actor 8@ into_turret_on_car 5@ at_car_offset 21@ 22@ 23@ position 0 shooting_angle_limit 24@ with_weapon 30
069B: attach_object 6@ to_actor 8@ with_offset 0.0 0.3 -0.56 rotation 0.0 0.0 90.0
04F4: put_actor 9@ into_turret_on_object 6@ offset_from_object_origin -0.3 0.0 0.7 orientation 3 both_side_angle_limit 0.0 lock_weapon 0
0812: AS_actor 9@ perform_animation "camstnd_idleloop" IFP "Camera" framedelta 4.0 loopA 1 lockX 0 lockY 0 lockF 0 time -1 // versionB
0208: 21@ = random_float_in_ranges -15.0 15.0
0208: 22@ = random_float_in_ranges -15.0 15.0
0129: 7@ = create_actor_pedtype 7 model 287 in_car 5@ driverseat
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 21@ 22@ 0.0
0704: car 5@ drive_to 21@ 22@ 23@
04BA: set_car 5@ speed_to 10.0
car.Health(5@) = 5000
0337: set_actor 8@ visibility 0
jump @WAR_600

:WAR_600
if
056D:   actor 2@ defined
jf @WAR_700
if
02E0:   actor 2@ firing_weapon
jf @WAR_700
0176: 31@ = object 3@ Z_angle
066E: create_particle "gunflash" attached_to_object 3@ with_offset 0.9 0.0 1.10 rotation 0.0 0.0 31@ flag 1 store_to 29@
064C: make_particle 29@ visible
066E: create_particle "gunsmoke" attached_to_object 3@ with_offset 0.9 0.0 1.10 rotation 0.0 0.0 31@ flag 1 store_to 29@
064C: make_particle 29@ visible
jump @WAR_700

:WAR_700
if
056D:   actor 12@ defined
jf @WAR_800
if
02E0:   actor 12@ firing_weapon
jf @WAR_800
0176: 31@ = object 13@ Z_angle
066E: create_particle "gunflash" attached_to_object 13@ with_offset 0.9 0.0 1.10 rotation 0.0 0.0 31@ flag 1 store_to 29@
064C: make_particle 29@ visible
066E: create_particle "gunsmoke" attached_to_object 13@ with_offset 0.9 0.0 1.10 rotation 0.0 0.0 31@ flag 1 store_to 29@
064C: make_particle 29@ visible
jump @WAR_800

:WAR_800
if
056D:   actor 8@ defined
jf @WAR_200
if
02E0:   actor 8@ firing_weapon
jf @WAR_200
0176: 31@ = object 6@ Z_angle
066E: create_particle "gunflash" attached_to_object 6@ with_offset 0.9 0.0 1.10 rotation 0.0 0.0 31@ flag 1 store_to 29@
064C: make_particle 29@ visible
066E: create_particle "gunsmoke" attached_to_object 6@ with_offset 0.9 0.0 1.10 rotation 0.0 0.0 31@ flag 1 store_to 29@
064C: make_particle 29@ visible
jump @WAR_200

:WAR_1000
wait 0
if
$WAR_WarStatus == 0
jf @WAR_200
if
056E:   car 0@ defined
jf @WAR_1100
0465: remove_actor 2@ from_turret_mode
0465: remove_actor 4@ from_turret_mode
wait 10
object.Destroy(3@)
actor.RemoveReferences(4@)
actor.RemoveReferences(2@)
actor.RemoveReferences(1@)
wait 10
actor.DestroyInstantly(4@)
actor.DestroyInstantly(2@)
actor.DestroyInstantly(1@)
car.Destroy(0@)
0@ = 0
jump @WAR_1100

:WAR_1100
wait 0
if
056E:   car 5@ defined
jf @WAR_1200
0465: remove_actor 8@ from_turret_mode
0465: remove_actor 9@ from_turret_mode
wait 10
object.Destroy(6@)
actor.RemoveReferences(9@)
actor.RemoveReferences(8@)
actor.RemoveReferences(7@)
wait 10
actor.DestroyInstantly(9@)
actor.DestroyInstantly(8@)
actor.DestroyInstantly(7@)
car.RemoveReferences(5@)
5@ = 0
jump @WAR_1200

:WAR_1200
wait 0
if
056E:   car 10@ defined
jf @WAR_1000
0465: remove_actor 12@ from_turret_mode
0465: remove_actor 14@ from_turret_mode
wait 10
object.Destroy(13@)
actor.RemoveReferences(14@)
actor.RemoveReferences(12@)
actor.RemoveReferences(11@)
wait 10
actor.DestroyInstantly(14@)
actor.DestroyInstantly(12@)
actor.DestroyInstantly(11@)
car.Destroy(10@)
10@ = 0
jump @WAR_1000