{$CLEO .cs}

Thread "PARA"

:PARA_10
wait 500
if and    
$WAR_WarStatus == 1
player.Defined($PLAYER_CHAR)
jf @PARA_10
077E: get_active_interior_to 31@
if
  31@ == 0
jf @PARA_10
Model.Load(356)
model.Load(285)
model.Load(2903)
04ED: load_animation  "PARACHUTE"
038B: load_requested_models
if and
model.Available(2903)
model.Available(285)
model.Available(356)
04EE:   animation "PARACHUTE" loaded
jf @PARA_10
30@ = 0
29@ = 0
jump @PARA_30

:PARA_20
wait 0
30@ += 1

:PARA_30
wait 0
if
$WAR_WarStatus == 1
jf @PARA_1000
if
player.Defined($Player_Char)
jf @PARA_111
0819: 22@ = actor $PLAYER_ACTOR distance_from_ground
if
22@ <= 70.0
jf @PARA_111
if
30@ <= 4
jf @PARA_31
5@(30@,5i) = object.Create(2903, 0.0, 0.0, -10.0)
0208: 22@ = random_float_in_ranges 30.0 40.0 
0208: 21@ = random_float_in_ranges -50.0 70.0 
0208: 20@ = random_float_in_ranges -50.0 50.0
08D2: object 5@(30@,5i) scale_model 0.34
04C4: store_coords_to 20@ 21@ 22@ from_actor $PLAYER_ACTOR with_offset 20@ 21@ 22@
0@(30@,5i) = actor.Create(Gang2, 285, 20@, 21@, 22@)
20@ = actor.Angle($PLAYER_ACTOR)
actor.Angle(0@(30@,5i)) = 20@
actor.Health(0@(30@,5i)) = 150
088A: actor 0@(30@,5i) perform_animation "PARA_FLOAT" IFP "PARACHUTE" 8.0 loopA 1 lockX 0 lockY 0 lockF 1 time -1 disable_force 0 disable_lockZ 1
069B: attach_object 5@(30@,5i) to_actor 0@(30@,5i) with_offset 0.0 -0.4 2.4 rotation 0.0 0.0 0.0
actor.LockInCurrentPosition(0@(30@,5i), True)
if
29@ == 1
jf @PARA_20
jump @PARA_110

:PARA_31
30@ = 0
29@ = 1
if 
056D:   actor 0@(30@,5i) defined
jf @PARA_30
jump @PARA_110

:PARA_100
0819: 23@ = actor 0@(30@,5i) distance_from_ground
if
84E7:   not object 5@(30@,5i) in_water
jf @PARA_105
if
23@ <= 1.0
jf @PARA_120
0605: actor 0@(30@,5i) perform_animation_sequence "PARA_FLOAT" IFP_file "PARACHUTE" 4.0 loop 0 0 0 0 time 1
object.Destroy(5@(30@,5i))
07DD: set_actor 0@(30@,5i) attack_rate 50
0946: set_actor 0@(30@,5i) actions_uninterupted_by_weapon_fire 0
actor.GiveWeaponAndAmmo(0@(30@,5i), 31, 9999)
actor.LockInCurrentPosition(0@(30@,5i), False)
087E: set_actor 0@(30@,5i) weapon_droppable 0
04C4: store_coords_to 21@ 22@ 23@ from_actor $PLAYER_ACTOR with_offset 0.0 0.0 0.0
0208: 24@ = random_float_in_ranges -7.0 7.0
005B: 21@ += 24@  
0208: 24@ = random_float_in_ranges -7.0 7.0
005B: 22@ += 24@
23@ += 5.0
02CE: 23@ = ground_z_at 21@ 22@ 23@
05D3: AS_actor 0@(30@,5i) goto_point 21@ 22@ 23@ mode 6 time -1 ms 
jump @PARA_120

:PARA_105
object.Destroy(5@(30@,5i))
actor.DestroyWithFade(0@(30@,5i))
jump @PARA_120

:PARA_110
wait 0
if
$WAR_WarStatus == 1
jf @PARA_1000
if
03CA:   object 5@(30@,5i) exists
jf @PARA_120
04C4: store_coords_to 20@ 21@ 22@ from_actor 0@(30@,5i) with_offset 0.0 0.0 0.0
21@ += 0.1
22@ -= 1.3
actor.PutAt(0@(30@,5i), 20@, 21@, 22@)
jump @PARA_100

:PARA_111
30@ += 1
if
30@ >= 5
jf @PARA_110
30@ = 0
jump @PARA_110

:PARA_120
if
$WAR_WarStatus == 1
jf @PARA_1000
if 
056D:   actor 0@(30@,5i) defined
jf @PARA_30
if or
0118:   actor 0@(30@,5i) dead
8104:   not actor $PLAYER_ACTOR near_actor 0@(30@,5i) radius 80.0 80.0 120.0 sphere 0
jf @PARA_111
actor.RemoveReferences(0@(30@,5i))
if
03CA:   object 5@(30@,5i) exists
jf @PARA_30
object.Destroy(5@(30@,5i))
jump @PARA_30

:PARA_1000
30@ = 0

:PARA_1100
if 
056D:   actor 0@(30@,5i) defined
jf @PARA_1200
object.Destroy(5@(30@,5i))
actor.DestroyInstantly(0@(30@,5i))

:PARA_1200
30@ += 1
if
30@ >= 5
jf @PARA_1100
jump @PARA_10