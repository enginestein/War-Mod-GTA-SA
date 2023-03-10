{$CLEO .cs}
{$USE ini}

Thread "WAR"

:WAR_100
wait 500
if and
$WAR_WarStatus == 1
player.Defined($Player_Char)
jf @WAR_100
model.Load(476)
model.Load(342)
model.Load(287)
if and
model.Available(476)
model.Available(342)
model.Available(287)
jf @WAR_100
32@ = 55000
33@ = 0
26@ = 0
if
0AAB:   file_exists "CLEO/SOUNDS/war_sounds.mp3"
jf @WAR_110
30@ = audiostream.Load("CLEO/SOUNDS/war_sounds.mp3")

:WAR_110
0AAB:   file_exists "CLEO/SOUNDS/siren.mp3"
jf @WAR_200
31@ = audiostream.Load("CLEO/SOUNDS/siren.mp3")

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
0205:   actor $PLAYER_ACTOR near_car 0@ radius 400.0 400.0 400.0 flag 0
jf @WAR_250
0227: 21@ = car 0@ health
if or
04E7:   object 19@ in_water
21@ <= 10
jf @WAR_400
if and
object.Destroy(19@)
actor.RemoveReferences(1@)
car.RemoveReferences(0@)
0@ = 0
32@ = 0
26@ = 0
33@ = 0
29@ = 0
jump @WAR_300

:WAR_250
object.Destroy(19@)
actor.DestroyInstantly(1@)
car.Destroy(0@)
0@ = 0
26@ = 0
33@ = 0
29@ = 0

:WAR_300
0819: 3@ = actor $PLAYER_ACTOR distance_from_ground
if
3@ <= 90.0
jf @WAR_200
if
32@ >= 60000
jf @WAR_200
0208: 14@ = random_float_in_ranges -90.0 90.0
04C4: store_coords_to 6@ 7@ 8@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 10.0
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ 250.0 35.0
if
06BD:   no_obstacles_between 6@ 7@ 8@ and 3@ 4@ 5@ solid 1 car 0 actor 0 object 0 particle 0
jf @WAR_200
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ 250.0 35.0
00A5: 0@ = create_car 476 at 3@ 4@ 5@
17@ = actor.Angle($PLAYER_ACTOR)
17@ += 180.0
0175: set_car 0@ Z_angle_to 17@
0129: 1@ = create_actor_pedtype 7 model 287 in_car 0@ driverseat
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ 0.0 15.0
04D2: set_plane 0@ fly_autopilot_around_point 3@ 4@ 5@ altitude_between 20.0 and 40.0
04BA: set_car 0@ speed_to 50.0
object.Create(19@, 342, 0.0, 0.0, 0.0)
object.CollisionDetection(19@, False)
0681: attach_object 19@ to_car 0@ with_offset 0.0 0.0 0.0 rotation 0.0 0.0 0.0
26@ = 0
33@ = 0
29@ = 0
jump @WAR_400

:WAR_400
if and
29@ <= 20
01AD:   car 0@ sphere 0 near_point 3@ 4@ radius 65.0 65.0
jf @WAR_600
if
0AAB:   file_exists "CLEO/SOUNDS/war_sounds.mp3"
jf @WAR_410
audiostream.PerformAction(30@, PLAY)

:WAR_410
wait 10
0407: store_coords_to 6@ 7@ 8@ from_car 0@ with_offset 0.0 3.0 -1.3
0407: store_coords_to 9@ 10@ 11@ from_car 0@ with_offset 0.0 40.0 -10.0
0208: 12@ = random_float_in_ranges -20.0 20.0
005B: 9@ += 12@  // (float)
0208: 12@ = random_float_in_ranges -15.0 15.0
005B: 10@ += 12@  // (float)
02CE: 11@ = ground_z_at 9@ 10@ 11@
06BC: create_M4_shoot_from 6@ 7@ 8@ target 9@ 10@ 11@ energy 25
066B: 27@ = attach_particle "TANK_FIRE" to_car 0@ with_offset 0.0 3.0 -1.3 type 1
064C: make_particle 27@ visible
064F: remove_references_to_particle 27@
020C: create_explosion_with_radius 2 at 9@ 10@ 11@
26@ = 1
33@ = 0
29@ += 1
jump @WAR_200

:WAR_500
if or
33@ >= 30000
26@ >= 1
jf @WAR_200
0208: 15@ = random_float_in_ranges -90.0 90.0
0208: 14@ = random_float_in_ranges -90.0 90.0
04C4: store_coords_to 3@ 4@ 5@ from_actor $PLAYER_ACTOR with_offset 14@ 15@ 15.0
04D2: set_plane 0@ fly_autopilot_around_point 3@ 4@ 5@ altitude_between 20.0 and 40.0
26@ = 0
33@ = 0
29@ = 0
jump @WAR_200

:WAR_600
if
26@ >= 1
jf @WAR_500
if
0AAB:   file_exists "CLEO/SOUNDS/siren.mp3"
jf @WAR_500
wait 1000
audiostream.PerformAction(31@, PLAY)
jump @WAR_500

:WAR_1000
wait 0
if
$WAR_WarStatus == 0
jf @WAR_200
if
056E:   car 0@ defined
jf @WAR_1000
object.Destroy(19@)
actor.DestroyInstantly(1@)
car.Destroy(0@)
0@ = 0
jump @WAR_1000