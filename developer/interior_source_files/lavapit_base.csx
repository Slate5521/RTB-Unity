<?xml version="1.0" encoding="utf-8" standalone="yes" ?>
<!--Torque Constructor Scene document http://www.garagegames.com-->
<ConstructorScene version="4" creator="Torque Constructor" date="2017/08/18 16:59:10">
    <Sunlight azimuth="180" elevation="35" color="255 255 255" ambient="64 64 64" />
    <LightingOptions lightingSystem="" ineditor_defaultLightmapSize="256" ineditor_maxLightmapSize="256" ineditor_lightingPerformanceHint="0" ineditor_shadowPerformanceHint="1" ineditor_TAPCompatibility="0" ineditor_useSunlight="0" export_defaultLightmapSize="256" export_maxLightmapSize="256" export_lightingPerformanceHint="0" export_shadowPerformanceHint="1" export_TAPCompatibility="0" export_useSunlight="0" />
    <GameTypes>
        <GameType name="Constructor" />
        <GameType name="Torque" />
    </GameTypes>
    <SceneGroups nextGroupID="2">
        <SceneGroup id="0" />
        <SceneGroup id="1" />
    </SceneGroups>
    <DetailLevels current="0">
        <DetailLevel minPixelSize="0" actionCenter="0 0 0">
            <InteriorMap brushScale="32" lightScale="8" ambientColor="0 0 0" ambientColorEmerg="0 0 0">
                <Entities nextEntityID="2">
                    <Entity id="0" classname="worldspawn" gametype="Torque" isPointEntity="0">
                        <Properties detail_number="0" min_pixels="250" geometry_scale="32.0" light_geometry_scale="8.0" light_smoothing_scale="4.0" light_mesh_scale="1.0" ambient_color="0 0 0" emergency_ambient_color="0 0 0" mapversion="220" />
                    </Entity>
                </Entities>
                <Brushes nextBrushID="40">
                    <Brush id="0" owner="0" type="0" pos="0 0 -0.5" rot="1 0 0 0" scale="" transform="0.545453 0 0 0 0 0.545453 0 0 0 0 1 -0.5 0 0 0 1" group="-1" locked="0" nextFaceID="235" nextVertexID="9">
                        <Vertices>
                            <Vertex pos="33 33 0.5" />
                            <Vertex pos="33 33 -0.5" />
                            <Vertex pos="33 -33 0.5" />
                            <Vertex pos="33 -33 -0.5" />
                            <Vertex pos="-33 33 0.5" />
                            <Vertex pos="-33 33 -0.5" />
                            <Vertex pos="-33 -33 0.5" />
                            <Vertex pos="-33 -33 -0.5" />
                        </Vertices>
                        <Face id="228" plane="1 -0 0 -33" album="Auxiliary" material="asphalt_1" texgens="0 1 0 1056 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 3 2 0 1" />
                        </Face>
                        <Face id="229" plane="-1 0 0 -33" album="Auxiliary" material="asphalt_1" texgens="0 -1 0 1056 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 5 4 6" />
                        </Face>
                        <Face id="230" plane="0 1 -0 -33" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 1056 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 5 1 0 4" />
                        </Face>
                        <Face id="231" plane="0 -1 0 -33" album="Auxiliary" material="asphalt_1" texgens="1 0 0 1056 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 6 2 3" />
                        </Face>
                        <Face id="232" plane="-0 0 1 -0.5" album="Auxiliary" material="asphalt_1" texgens="0.545453 0 0 0 0 -0.545453 0 0 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 6 4 0 2" />
                        </Face>
                        <Face id="233" plane="0 0 -1 -0.5" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 1056 0 -1 0 -1056 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 3 1 5" />
                        </Face>
                    </Brush>
                    <Brush id="5" owner="0" type="0" pos="0 -17.5 8" rot="1 0 0 0" scale="" transform="34 0 0 0 0 0.015625 0 -17.5 0 0 1 8 0 0 0 1" group="-1" locked="0" nextFaceID="1489" nextVertexID="9">
                        <Vertices>
                            <Vertex pos="0.5 32 8" />
                            <Vertex pos="0.5 32 -8" />
                            <Vertex pos="0.5 -32 8" />
                            <Vertex pos="0.5 -32 -8" />
                            <Vertex pos="-0.5 32 8" />
                            <Vertex pos="-0.5 32 -8" />
                            <Vertex pos="-0.5 -32 8" />
                            <Vertex pos="-0.5 -32 -8" />
                        </Vertices>
                        <Face id="1482" plane="1 -0 0 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 1 0 1024 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 3 2 0 1" />
                        </Face>
                        <Face id="1483" plane="-1 0 0 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 -1 0 1024 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 5 4 6" />
                        </Face>
                        <Face id="1484" plane="0 1 -0 -32" album="Auxiliary" material="asphalt_1" texgens="34 0 0 0 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 5 1 0 4" />
                        </Face>
                        <Face id="1485" plane="0 -1 0 -32" album="Auxiliary" material="asphalt_1" texgens="1 0 0 16 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 6 2 3" />
                        </Face>
                        <Face id="1486" plane="-0 0 1 -8" album="Auxiliary" material="asphalt_1" texgens="1 0 0 16 0 -1 0 -1024 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 6 4 0 2" />
                        </Face>
                        <Face id="1487" plane="0 0 -1 -8" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 16 0 -1 0 -1024 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 3 1 5" />
                        </Face>
                    </Brush>
                    <Brush id="28" owner="0" type="0" pos="5 -13 16.5" rot="0 0 1 3.14159" scale="" transform="-0.634146 -5.54388e-008 0 5 3.49691e-008 -0.4 0 -13 0 0 1 16.5 0 0 0 1" group="-1" locked="0" nextFaceID="2785" nextVertexID="9">
                        <Vertices>
                            <Vertex pos="20.5 12.5 0.5" />
                            <Vertex pos="20.5 12.5 -0.5" />
                            <Vertex pos="20.5 -12.5 0.5" />
                            <Vertex pos="20.5 -12.5 -0.5" />
                            <Vertex pos="-20.5 12.5 0.5" />
                            <Vertex pos="-20.5 12.5 -0.5" />
                            <Vertex pos="-20.5 -12.5 0.5" />
                            <Vertex pos="-20.5 -12.5 -0.5" />
                        </Vertices>
                        <Face id="2778" plane="1 -0 0 -20.5" album="Auxiliary" material="asphalt_1" texgens="0 1 0 400 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 3 2 0 1" />
                        </Face>
                        <Face id="2779" plane="-1 0 0 -20.5" album="Auxiliary" material="asphalt_1" texgens="0 -1 0 400 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 5 4 6" />
                        </Face>
                        <Face id="2780" plane="0 1 -0 -12.5" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 656 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 5 1 0 4" />
                        </Face>
                        <Face id="2781" plane="0 -1 0 -12.5" album="Auxiliary" material="asphalt_1" texgens="1 0 0 656 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 6 2 3" />
                        </Face>
                        <Face id="2782" plane="-0 0 1 -0.5" album="Auxiliary" material="asphalt_1" texgens="-0.634146 0 0 160 0 0.4 0 416 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 6 4 0 2" />
                        </Face>
                        <Face id="2783" plane="0 0 -1 -0.5" album="Auxiliary" material="asphalt_1" texgens="-0.634146 0 0 160 0 0.4 0 416 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 3 1 5" />
                        </Face>
                    </Brush>
                    <Brush id="30" owner="0" type="0" pos="17.5 0 8" rot="1 0 0 0" scale="" transform="1 0 0 17.5 0 0.562499 0 0 0 0 1 8 0 0 0 1" group="-1" locked="0" nextFaceID="1489" nextVertexID="9">
                        <Vertices>
                            <Vertex pos="0.5 32 8" />
                            <Vertex pos="0.5 32 -8" />
                            <Vertex pos="0.5 -32 8" />
                            <Vertex pos="0.5 -32 -8" />
                            <Vertex pos="-0.5 32 8" />
                            <Vertex pos="-0.5 32 -8" />
                            <Vertex pos="-0.5 -32 8" />
                            <Vertex pos="-0.5 -32 -8" />
                        </Vertices>
                        <Face id="1482" plane="1 -0 0 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 1 0 1024 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 3 2 0 1" />
                        </Face>
                        <Face id="1483" plane="-1 0 0 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 0.562499 0 0 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 5 4 6" />
                        </Face>
                        <Face id="1484" plane="0 1 -0 -32" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 16 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 5 1 0 4" />
                        </Face>
                        <Face id="1485" plane="0 -1 0 -32" album="Auxiliary" material="asphalt_1" texgens="1 0 0 16 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 6 2 3" />
                        </Face>
                        <Face id="1486" plane="-0 0 1 -8" album="Auxiliary" material="asphalt_1" texgens="1 0 0 16 0 -1 0 -1024 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 6 4 0 2" />
                        </Face>
                        <Face id="1487" plane="0 0 -1 -8" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 16 0 -1 0 -1024 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 3 1 5" />
                        </Face>
                    </Brush>
                    <Brush id="31" owner="0" type="0" pos="13 5 16.5" rot="0 0 1 4.71239" scale="" transform="-2.82894e-009 -0.4 0 13 0.634146 3.15969e-008 0 5 0 0 1 16.5 0 0 0 1" group="-1" locked="0" nextFaceID="2785" nextVertexID="9">
                        <Vertices>
                            <Vertex pos="20.5 12.5 0.5" />
                            <Vertex pos="20.5 12.5 -0.5" />
                            <Vertex pos="20.5 -12.5 0.5" />
                            <Vertex pos="20.5 -12.5 -0.5" />
                            <Vertex pos="-20.5 12.5 0.5" />
                            <Vertex pos="-20.5 12.5 -0.5" />
                            <Vertex pos="-20.5 -12.5 0.5" />
                            <Vertex pos="-20.5 -12.5 -0.5" />
                        </Vertices>
                        <Face id="2778" plane="1 -0 0 -20.5" album="Auxiliary" material="asphalt_1" texgens="0 1 0 400 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 3 2 0 1" />
                        </Face>
                        <Face id="2779" plane="-1 0 0 -20.5" album="Auxiliary" material="asphalt_1" texgens="0 -1 0 400 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 5 4 6" />
                        </Face>
                        <Face id="2780" plane="0 1 -0 -12.5" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 656 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 5 1 0 4" />
                        </Face>
                        <Face id="2781" plane="0 -1 0 -12.5" album="Auxiliary" material="asphalt_1" texgens="1 0 0 656 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 6 2 3" />
                        </Face>
                        <Face id="2782" plane="-0 0 1 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 -0.4 0 416 -0.634146 0 0 -160 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 6 4 0 2" />
                        </Face>
                        <Face id="2783" plane="0 0 -1 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 -0.4 0 416 -0.634146 0 0 -160 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 3 1 5" />
                        </Face>
                    </Brush>
                    <Brush id="36" owner="0" type="0" pos="-5 13 16.5" rot="1 0 0 0" scale="" transform="0.634146 2.04697e-008 0 -5 2.04697e-008 0.4 0 13 0 0 1 16.5 0 0 0 1" group="-1" locked="0" nextFaceID="2785" nextVertexID="9">
                        <Vertices>
                            <Vertex pos="20.5 12.5 0.5" />
                            <Vertex pos="20.5 12.5 -0.5" />
                            <Vertex pos="20.5 -12.5 0.5" />
                            <Vertex pos="20.5 -12.5 -0.5" />
                            <Vertex pos="-20.5 12.5 0.5" />
                            <Vertex pos="-20.5 12.5 -0.5" />
                            <Vertex pos="-20.5 -12.5 0.5" />
                            <Vertex pos="-20.5 -12.5 -0.5" />
                        </Vertices>
                        <Face id="2778" plane="1 -0 0 -20.5" album="Auxiliary" material="asphalt_1" texgens="0 1 0 400 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 3 2 0 1" />
                        </Face>
                        <Face id="2779" plane="-1 0 0 -20.5" album="Auxiliary" material="asphalt_1" texgens="0 -1 0 400 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 5 4 6" />
                        </Face>
                        <Face id="2780" plane="0 1 -0 -12.5" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 656 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 5 1 0 4" />
                        </Face>
                        <Face id="2781" plane="0 -1 0 -12.5" album="Auxiliary" material="asphalt_1" texgens="1 0 0 656 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 6 2 3" />
                        </Face>
                        <Face id="2782" plane="-0 0 1 -0.5" album="Auxiliary" material="asphalt_1" texgens="0.634146 0 0 -160 0 -0.4 0 -416 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 6 4 0 2" />
                        </Face>
                        <Face id="2783" plane="0 0 -1 -0.5" album="Auxiliary" material="asphalt_1" texgens="0.634146 0 0 -160 0 -0.4 0 -416 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 3 1 5" />
                        </Face>
                    </Brush>
                    <Brush id="37" owner="0" type="0" pos="-13 -5 16.5" rot="-0 0 1 1.5708" scale="" transform="5.82677e-008 0.4 0 -13 -0.634146 3.37217e-009 0 -5 0 0 1 16.5 0 0 0 1" group="-1" locked="0" nextFaceID="2785" nextVertexID="9">
                        <Vertices>
                            <Vertex pos="20.5 12.5 0.5" />
                            <Vertex pos="20.5 12.5 -0.5" />
                            <Vertex pos="20.5 -12.5 0.5" />
                            <Vertex pos="20.5 -12.5 -0.5" />
                            <Vertex pos="-20.5 12.5 0.5" />
                            <Vertex pos="-20.5 12.5 -0.5" />
                            <Vertex pos="-20.5 -12.5 0.5" />
                            <Vertex pos="-20.5 -12.5 -0.5" />
                        </Vertices>
                        <Face id="2778" plane="1 -0 0 -20.5" album="Auxiliary" material="asphalt_1" texgens="0 1 0 400 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 3 2 0 1" />
                        </Face>
                        <Face id="2779" plane="-1 0 0 -20.5" album="Auxiliary" material="asphalt_1" texgens="0 -1 0 400 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 5 4 6" />
                        </Face>
                        <Face id="2780" plane="0 1 -0 -12.5" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 656 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 5 1 0 4" />
                        </Face>
                        <Face id="2781" plane="0 -1 0 -12.5" album="Auxiliary" material="asphalt_1" texgens="1 0 0 656 0 0 -1 -16 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 6 2 3" />
                        </Face>
                        <Face id="2782" plane="-0 0 1 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 0.4 0 -416 0.634146 0 0 160 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 6 4 0 2" />
                        </Face>
                        <Face id="2783" plane="0 0 -1 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 0.4 0 -416 0.634146 0 0 160 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 3 1 5" />
                        </Face>
                    </Brush>
                    <Brush id="38" owner="0" type="0" pos="0 17.5 8" rot="0 0 -1 3.14159" scale="" transform="-34 1.36598e-009 0 0 -2.97237e-006 -0.015625 0 17.5 0 0 1 8 0 0 0 1" group="-1" locked="0" nextFaceID="1489" nextVertexID="9">
                        <Vertices>
                            <Vertex pos="0.5 32 8" />
                            <Vertex pos="0.5 32 -8" />
                            <Vertex pos="0.5 -32 8" />
                            <Vertex pos="0.5 -32 -8" />
                            <Vertex pos="-0.5 32 8" />
                            <Vertex pos="-0.5 32 -8" />
                            <Vertex pos="-0.5 -32 8" />
                            <Vertex pos="-0.5 -32 -8" />
                        </Vertices>
                        <Face id="1482" plane="1 -0 0 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 1 0 1024 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 3 2 0 1" />
                        </Face>
                        <Face id="1483" plane="-1 0 0 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 -1 0 1024 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 5 4 6" />
                        </Face>
                        <Face id="1484" plane="0 1 -0 -32" album="Auxiliary" material="asphalt_1" texgens="-34 0.00646788 0 -231.809 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 5 1 0 4" />
                        </Face>
                        <Face id="1485" plane="0 -1 0 -32" album="Auxiliary" material="asphalt_1" texgens="1 0 0 16 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 6 2 3" />
                        </Face>
                        <Face id="1486" plane="-0 0 1 -8" album="Auxiliary" material="asphalt_1" texgens="1 0 0 16 0 -1 0 -1024 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 6 4 0 2" />
                        </Face>
                        <Face id="1487" plane="0 0 -1 -8" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 16 0 -1 0 -1024 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 3 1 5" />
                        </Face>
                    </Brush>
                    <Brush id="39" owner="0" type="0" pos="-17.5 0 8" rot="0 0 -1 3.14159" scale="" transform="-1 4.78093e-008 0 -17.5 -8.99206e-008 -0.562499 0 0 0 0 1 8 0 0 0 1" group="-1" locked="0" nextFaceID="1489" nextVertexID="9">
                        <Vertices>
                            <Vertex pos="0.5 32 8" />
                            <Vertex pos="0.5 32 -8" />
                            <Vertex pos="0.5 -32 8" />
                            <Vertex pos="0.5 -32 -8" />
                            <Vertex pos="-0.5 32 8" />
                            <Vertex pos="-0.5 32 -8" />
                            <Vertex pos="-0.5 -32 8" />
                            <Vertex pos="-0.5 -32 -8" />
                        </Vertices>
                        <Face id="1482" plane="1 -0 0 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 1 0 1024 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 3 2 0 1" />
                        </Face>
                        <Face id="1483" plane="-1 0 0 -0.5" album="Auxiliary" material="asphalt_1" texgens="0 -0.562499 0 0 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 5 4 6" />
                        </Face>
                        <Face id="1484" plane="0 1 -0 -32" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 16 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 5 1 0 4" />
                        </Face>
                        <Face id="1485" plane="0 -1 0 -32" album="Auxiliary" material="asphalt_1" texgens="1 0 0 16 0 0 -1 -256 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 6 2 3" />
                        </Face>
                        <Face id="1486" plane="-0 0 1 -8" album="Auxiliary" material="asphalt_1" texgens="1 0 0 16 0 -1 0 -1024 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 6 4 0 2" />
                        </Face>
                        <Face id="1487" plane="0 0 -1 -8" album="Auxiliary" material="asphalt_1" texgens="-1 0 0 16 0 -1 0 -1024 0 1 1" texRot="0" texScale="1 1" texDiv="256 256">
                            <Indices indices=" 7 3 1 5" />
                        </Face>
                    </Brush>
                </Brushes>
            </InteriorMap>
        </DetailLevel>
    </DetailLevels>
</ConstructorScene>
